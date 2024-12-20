﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConversionCalcExample {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ResourceMain {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceMain() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ConversionCalcExample.ResourceMain", typeof(ResourceMain).Assembly);
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
        ///   Looks up a localized string similar to Reuse.
        /// </summary>
        internal static string rxUnit {
            get {
                return ResourceManager.GetString("rxUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (?&lt;expression&gt;(?&lt;value&gt;-{0,1}[0-9]+(\.[0-9]+){0,1})\s*(?&lt;unit&gt;.*)).
        /// </summary>
        internal static string rxValueUnit {
            get {
                return ResourceManager.GetString("rxValueUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Demonstrate the functionality of the ConversionCalc library.
        ///
        ///Syntax:
        ///ConversionCalcExample /convertfrom:{ValueAndUnit} /convertto:{Unit} [/wait]
        ///
        ///    {ValueAndUnit}  -   A value followed by its associated unit.
        ///    {Unit}          -   A unit only.
        ///    /wait           -   When specified, the application will wait for the user
        ///                        to press [Enter] after processing has completed and
        ///                        before closing the application.
        ///
        ///Example:
        ///ConversionCalcExample /convert [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Syntax {
            get {
                return ResourceManager.GetString("Syntax", resourceCulture);
            }
        }
    }
}
