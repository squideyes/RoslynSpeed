#region Copyright, Author Details and Related Context 
//<notice lastUpdateOn="12/5/2015"> 
//  <solution>RoslynSpeed</solution>
//  <assembly>UsingCodeAnalysis</assembly> 
//  <description>A demo of the 5x slowdown of Microsoft.CodeAnalysis.CSharp v1.1.1 vs. v.1.1.0</description> 
//  <copyright> 
//    Copyright (C) 2015 Louis S. Berman  

//    This program is free software: you can redistribute it and/or modify 
//    it under the terms of the GNU General Public License as published by 
//    the Free Software Foundation, either version 3 of the License, or 
//    (at your option) any later version. 
 
//    This program is distributed in the hope that it will be useful, 
//    but WITHOUT ANY WARRANTY; without even the implied warranty of 
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the 
//    GNU General Public License for more details.  

//    You should have received a copy of the GNU General Public License 
//    along with this program.  If not, see http://www.gnu.org/licenses/. 
//  </copyright> 
//  <author> 
//    <fullName>Louis S. Berman</fullName> 
//    <email>louis@squideyes.com</email> 
//    <website>http://squideyes.com</website> 
//  </author> 
//</notice> 
#endregion
  
using Common;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace UsingCodeAnalysis
{
    public static class GenomeRunner
    {
        private static CSharpCompilationOptions compilationOptions =
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
                optimizationLevel: OptimizationLevel.Release);

        public static CohortStats<R> Run<S, R>(Cohort cohort, S settings, string source,
            MetadataReference[] references, CancellationTokenSource cts, Action<Progress> onProgress)
            where S : SettingsBase
            where R : ReportBase<R>
        {
            settings.Validate();

            var runStartedOn = DateTime.UtcNow;

            var syntaxTree = CSharpSyntaxTree.ParseText(source);

            var entityCount = syntaxTree.GetRoot().DescendantNodes().
                OfType<ClassDeclarationSyntax>().Count();

            int progress = 0;

            onProgress(new Progress(0, entityCount));

            var compilation = CSharpCompilation.Create(
                assemblyName: Guid.NewGuid().ToString("N"),
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: compilationOptions);

            CohortStats<R> stats;

            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms, cancellationToken: cts.Token);

                if (!result.Success)
                {
                    var failures = (result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error)).ToList();

                    throw new EmitException(cohort, failures);
                }

                ms.Seek(0, SeekOrigin.Begin);

                var assembly = Assembly.Load(ms.ToArray());

                stats = new CohortStats<R>(cohort, assembly.GetTypes());

                var errors = new ConcurrentQueue<Exception>();

                Parallel.ForEach(
                    stats,
                    new ParallelOptions()
                    {
                        CancellationToken = cts.Token,
                        MaxDegreeOfParallelism = Environment.ProcessorCount
                    },
                    runInfo =>
                    {
                        try
                        {
                            var instanceStartedOn = DateTime.UtcNow;

                            var instance = Activator.CreateInstance(runInfo.Type,
                                runInfo.KnownAs, settings) as IGenome<R>;

                            instance.Execute();

                            instance.Report.SetElapsed(instanceStartedOn);

                            runInfo.Report = instance.Report;

                            var p = Interlocked.Increment(ref progress);

                            onProgress(new Progress(p, entityCount));
                        }
                        catch (Exception error)
                        {
                            errors.Enqueue(error);
                        }
                    });

                if (errors.Count > 0)
                    throw new AggregateException(errors);
            }

            stats.Sort();

            stats.SetElapsed(runStartedOn);

            return stats;
        }
    }
}
