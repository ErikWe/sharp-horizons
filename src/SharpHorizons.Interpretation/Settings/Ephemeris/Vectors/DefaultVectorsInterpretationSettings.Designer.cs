﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharpHorizons.Settings.Interpretation.Ephemeris.Vectors {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
    internal sealed partial class DefaultVectorsInterpretationSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static DefaultVectorsInterpretationSettings defaultInstance = ((DefaultVectorsInterpretationSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new DefaultVectorsInterpretationSettings())));
        
        public static DefaultVectorsInterpretationSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Output units")]
        public string OutputUnits {
            get {
                return ((string)(this["OutputUnits"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Output type")]
        public string VectorCorrection {
            get {
                return ((string)(this["VectorCorrection"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Output format")]
        public string VectorTableContent {
            get {
                return ((string)(this["VectorTableContent"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Reference frame")]
        public string ReferencePlane {
            get {
                return ((string)(this["ReferencePlane"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Small perturbers")]
        public string SmallPerturbers {
            get {
                return ((string)(this["SmallPerturbers"]));
            }
        }
    }
}
