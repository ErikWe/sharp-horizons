﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpHorizons.Settings.Interpretation {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
    internal sealed partial class DefaultInterpretationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static DefaultInterpretationSettings defaultInstance = ((DefaultInterpretationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DefaultInterpretationSettings())));
        
        public static DefaultInterpretationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("US/Pacific")]
        public string HorizonsTimeZoneID {
            get {
                return ((string)(this["HorizonsTimeZoneID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("unavailable")]
        public string UnavailableText {
            get {
                return ((string)(this["UnavailableText"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("*****")]
        public string BlockSeparator {
            get {
                return ((string)(this["BlockSeparator"]));
            }
        }
    }
}