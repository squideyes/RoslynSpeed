﻿#region Copyright, Author Details and Related Context 
//<notice lastUpdateOn="12/5/2015"> 
//  <solution>RoslynSpeed</solution>
//  <assembly>Common.Properties</assembly> 
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
  
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Common.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;antTrail name=&quot;Default&quot; isDefault=&quot;True&quot;&gt;
        ///  &lt;cell x=&quot;0&quot;
        ///        y=&quot;0&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;1&quot;
        ///        y=&quot;0&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;2&quot;
        ///        y=&quot;0&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;3&quot;
        ///        y=&quot;0&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;3&quot;
        ///        y=&quot;1&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;3&quot;
        ///        y=&quot;2&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;3&quot;
        ///        y=&quot;3&quot;
        ///        kind=&quot;Food&quot; /&gt;
        ///  &lt;cell x=&quot;3&quot;
        ///        y=&quot;4&quot;
        ///        kind=&quot;Gap&quot; / [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Default {
            get {
                return ResourceManager.GetString("Default", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to using Common;
        ///
        ///namespace UsingCodeAnalysis
        ///{
        ///    public class Cohort0000_Entity0000 : Genome
        ///    {
        ///        public Cohort0000_Entity0000(KnownAs knownAs, Settings settings)
        ///            : base(knownAs, settings)
        ///        {
        ///        }
        ///        public override void Execute()
        ///        {
        ///            while (!IsFinished())
        ///            {
        ///                TurnRight();
        ///                Move();
        ///            }
        ///        }
        ///    }
        ///	public class Cohort0000_Entity0001 : Genome
        ///    {
        ///        public Cohort0000_Enti [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SourceCode {
            get {
                return ResourceManager.GetString("SourceCode", resourceCulture);
            }
        }
    }
}
