﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpHorizons.Query {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.4.0.0")]
    internal sealed partial class DefaultQuerySettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static DefaultQuerySettings defaultInstance = ((DefaultQuerySettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DefaultQuerySettings())));
        
        public static DefaultQuerySettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://ssd.jpl.nasa.gov/api/horizons.api")]
        public string APIAddress {
            get {
                return ((string)(this["APIAddress"]));
            }
        }
    }
}