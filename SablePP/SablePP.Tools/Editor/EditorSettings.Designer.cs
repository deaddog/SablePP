﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SablePP.Tools.Editor {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class EditorSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static EditorSettings defaultInstance = ((EditorSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new EditorSettings())));
        
        public static EditorSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DefaultCode {
            get {
                return ((string)(this["DefaultCode"]));
            }
            set {
                this["DefaultCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string RecentFiles {
            get {
                return ((string)(this["RecentFiles"]));
            }
            set {
                this["RecentFiles"] = value;
            }
        }
    }
}
