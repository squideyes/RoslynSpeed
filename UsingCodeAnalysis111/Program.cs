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
using System;
using System.Threading;

namespace UsingCodeAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Using Microsoft.CodeAnalysis.CSharp v1.1.1");

            Console.WriteLine();

            var cohort = new Cohort("Ant", 0);

            var settings = new Settings()
            {
                Grid = Grid.Load("Default"),
                FoodGoal = 76,
                StepGoal = 400
            };

            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(Cohort).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Settings).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location)
            };

            var cts = new CancellationTokenSource();

            try
            {
                Console.Write($"Running {cohort}");

                var stats = GenomeRunner.Run<Settings, Report>(
                    cohort, settings, WellKnown.SourceCode, references, cts,
                    progress =>
                    {
                        Console.Write('.');
                    });

                Console.WriteLine("Finished!");
                Console.WriteLine();

                int count = 0;

                foreach (var runInfo in stats)
                    Console.WriteLine($"{++count:00} of {stats.Count:00} - {runInfo}");

                var average = new TimeSpan(stats.Elapsed.Ticks / stats.Count);

                Console.WriteLine();

                Console.WriteLine($"Elapsed: {stats.Elapsed} (Average: {average})");
            }
            catch (AggregateException errors)
            {
                int count = 0;

                foreach (var error in errors.InnerExceptions)
                    Console.WriteLine($"Error {++count:000}: {error.Message}");
            }

            Console.WriteLine();
            Console.Write("Press any key to terminate...");

            Console.ReadKey(true);
        }
    }
}
