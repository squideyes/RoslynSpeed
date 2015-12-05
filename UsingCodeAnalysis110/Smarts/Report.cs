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
using System.Collections.Generic;

namespace UsingCodeAnalysis
{
    public class Report : ReportBase<Report>
    {
        public Report()
        {
            Route = new List<Point>();
        }

        public List<Point> Route { get; }

        public int FoodCount { get; internal set; }

        protected override int GetCompareTo(Report other)
        {
            if (other.FoodCount.CompareTo(FoodCount) == 0)
                return other.StepCount.CompareTo(StepCount);
            else
                return other.FoodCount.CompareTo(FoodCount);
        }

        public override string ToString()
        {
            return $"gathered {FoodCount} units of food in {StepCount} steps";
        }
    }
}
