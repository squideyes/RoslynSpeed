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
    public abstract class Genome : GenomeBase<Settings, Report>
    {
        private Facing facing = Facing.Right;
        private Point current = new Point(0, 0);
        private bool isFinished = false;
        private HashSet<Point> eaten = new HashSet<Point>();

        public Genome(KnownAs knownAs, Settings settings)
            : base(knownAs, settings)
        {
            Report.Route.Add(current);
        }

        private Point GetFacingCell()
        {
            var x = current.X;
            var y = current.Y;

            switch (facing)
            {
                case Facing.Left:
                    x = current.X.Advance(WellKnown.GridWidth - 1);
                    break;
                case Facing.Right:
                    x = current.X.Retreat(WellKnown.GridWidth - 1);
                    break;
                case Facing.Up:
                    y = current.Y.Advance(WellKnown.GridHeight - 1);
                    break;
                case Facing.Down:
                    y = current.Y.Retreat(WellKnown.GridHeight - 1);
                    break;
            }

            return new Point(x, y);
        }

        public override bool IsFinished()
        {
            if (!isFinished)
            {
                if ((Report.StepCount == Settings.StepGoal) ||
                    (Report.FoodCount == Settings.FoodGoal))
                {
                    isFinished = true;
                }
            }

            return isFinished;
        }

        public bool IsFacingFood()
        {
            return Settings.Grid[GetFacingCell()].IsFood();
        }

        public bool IsFacingGap()
        {
            return Settings.Grid[GetFacingCell()].IsGap();
        }

        public void Move()
        {
            if (IsFinished())
                return;

            current = GetFacingCell();

            Report.Route.Add(current);

            if (Settings.Grid[current].IsFood())
            {
                if (!eaten.Contains(current))
                {
                    eaten.Add(current);

                    Report.FoodCount++;

                    Report.Route.Add(current);
                }
            }

            Report.UpdateStats();
        }

        public void TurnLeft()
        {
            if (IsFinished())
                return;

            switch (facing)
            {
                case Facing.Left:
                    facing = Facing.Down;
                    break;
                case Facing.Right:
                    facing = Facing.Up;
                    break;
                case Facing.Up:
                    facing = Facing.Left;
                    break;
                case Facing.Down:
                    facing = Facing.Right;
                    break;
            }

            Report.UpdateStats();
        }

        public void TurnRight()
        {
            if (IsFinished())
                return;

            switch (facing)
            {
                case Facing.Left:
                    facing = Facing.Up;
                    break;
                case Facing.Right:
                    facing = Facing.Down;
                    break;
                case Facing.Up:
                    facing = Facing.Right;
                    break;
                case Facing.Down:
                    facing = Facing.Left;
                    break;
            }

            Report.UpdateStats();
        }
    }
}
