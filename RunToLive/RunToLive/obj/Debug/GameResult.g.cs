﻿#pragma checksum "..\..\GameResult.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C9B05D0B7BBA9B3019F1DBCB4F69D346"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using RunToLive;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace RunToLive {
    
    
    /// <summary>
    /// GameResults
    /// </summary>
    public partial class GameResults : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\GameResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label score;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\GameResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox info_text;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\GameResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button @return;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\GameResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stats_text;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\GameResult.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stats_number;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/RunToLive;component/gameresult.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\GameResult.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.score = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.info_text = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\GameResult.xaml"
            this.info_text.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.@return = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\GameResult.xaml"
            this.@return.Click += new System.Windows.RoutedEventHandler(this.return_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.stats_text = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\GameResult.xaml"
            this.stats_text.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.stats_number = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\GameResult.xaml"
            this.stats_number.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txt_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
