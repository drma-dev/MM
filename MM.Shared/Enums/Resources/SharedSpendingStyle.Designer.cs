﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MM.Shared.Enums.Resources {
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
    public class SharedSpendingStyle {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SharedSpendingStyle() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MM.Shared.Enums.Resources.SharedSpendingStyle", typeof(SharedSpendingStyle).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This spending style involves both partners contributing financially and splitting bills proportionally based on each person&apos;s income or financial situation..
        /// </summary>
        public static string Balanced_Description {
            get {
                return ResourceManager.GetString("Balanced_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Balanced.
        /// </summary>
        public static string Balanced_Name {
            get {
                return ResourceManager.GetString("Balanced_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This spending style involves one partner paying for everything and frequently offering gifts to their partner..
        /// </summary>
        public static string Benefactor_Description {
            get {
                return ResourceManager.GetString("Benefactor_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Benefactor.
        /// </summary>
        public static string Benefactor_Name {
            get {
                return ResourceManager.GetString("Benefactor_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This spending style involves both partners contributing financially, but one partner paying for fewer things and receiving gifts occasionally..
        /// </summary>
        public static string Contributor_Description {
            get {
                return ResourceManager.GetString("Contributor_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Contributor.
        /// </summary>
        public static string Contributor_Name {
            get {
                return ResourceManager.GetString("Contributor_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This spending style involves one partner paying for most things and occasionally offering gifts to their partner..
        /// </summary>
        public static string Provider_Description {
            get {
                return ResourceManager.GetString("Provider_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provider.
        /// </summary>
        public static string Provider_Name {
            get {
                return ResourceManager.GetString("Provider_Name", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This spending style involves one person not contributing financially and receiving gifts frequently from their partner..
        /// </summary>
        public static string Recipient_Description {
            get {
                return ResourceManager.GetString("Recipient_Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Recipient.
        /// </summary>
        public static string Recipient_Name {
            get {
                return ResourceManager.GetString("Recipient_Name", resourceCulture);
            }
        }
    }
}