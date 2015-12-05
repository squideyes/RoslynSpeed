#region Copyright, Author Details and Related Context 
//<notice lastUpdateOn="12/5/2015"> 
//  <solution>RoslynSpeed</solution>
//  <assembly>Common</assembly> 
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
  
using System;

namespace Common
{
    public class RunInfo<R> : IComparable<RunInfo<R>>
        where R : ReportBase<R>
    {
        public RunInfo(KnownAs knownAs, Type type)
        {
            KnownAs = knownAs;
            Type = type;
        }

        public KnownAs KnownAs { get; }
        public Type Type { get; }

        public R Report { get; set; }

        public int CompareTo(RunInfo<R> other)
        {
            return Report.CompareTo(other.Report);
        }

        public override string ToString()
        {
            return $"{KnownAs} {Report}";
        }
    }
}
