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
  
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Common
{
    public class Trail : IComparable<Trail>
    {
        private Trail(string name, bool isDefault, List<Cell> cells)
        {
            Name = name;
            IsDefault = isDefault;
            Cells = cells;
        }

        public string Name { get; private set; }
        public bool IsDefault { get; private set; }
        public List<Cell> Cells { get; private set; }

        public int CompareTo(Trail other)
        {
            return string.Compare(Name, other.Name, true);
        }

        public override string ToString()
        {
            return Name;
        }

        public static Trail Load(string xml)
        {
            var doc = XDocument.Parse(xml);

            var root = doc.Element("antTrail");

            var name = root.Attribute("name").Value;

            var isDefault = (bool)root.Attribute("isDefault");

            var cells = new List<Cell>();

            var q = from c in root.Elements("cell")
                    select new
                    {
                        X = (int)c.Attribute("x"),
                        Y = (int)c.Attribute("y"),
                        Kind = c.Attribute("kind").Value.ToEnum<CellKind>()
                    };

            foreach (var cell in q)
                cells.Add(new Cell(cell.X, cell.Y, cell.Kind));

            return new Trail(name, isDefault, cells);
        }
    }
}
