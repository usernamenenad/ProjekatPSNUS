﻿#pragma checksum "..\..\..\AddPlayer.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CD9A7117529CAED833B55F8AE99E780917770180"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using PL;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PL {
    
    
    /// <summary>
    /// AddPlayer
    /// </summary>
    public partial class AddPlayer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.UniformGrid Properties;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerFirstName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerLastName;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker PlayerDateOfBirth;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerAge;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerNationality;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerTeam;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerApperiances;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerGoals;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerAssists;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\AddPlayer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PlayerJerseyNumber;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PL;component/addplayer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddPlayer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Properties = ((System.Windows.Controls.Primitives.UniformGrid)(target));
            return;
            case 2:
            this.PlayerFirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\AddPlayer.xaml"
            this.PlayerFirstName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextualInputValidation);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PlayerLastName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\AddPlayer.xaml"
            this.PlayerLastName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextualInputValidation);
            
            #line default
            #line hidden
            return;
            case 4:
            this.PlayerDateOfBirth = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.PlayerAge = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\AddPlayer.xaml"
            this.PlayerAge.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalInputValidation);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PlayerNationality = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\AddPlayer.xaml"
            this.PlayerNationality.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextualInputValidation);
            
            #line default
            #line hidden
            return;
            case 7:
            this.PlayerTeam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.PlayerApperiances = ((System.Windows.Controls.TextBox)(target));
            
            #line 49 "..\..\..\AddPlayer.xaml"
            this.PlayerApperiances.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalInputValidation);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PlayerGoals = ((System.Windows.Controls.TextBox)(target));
            
            #line 53 "..\..\..\AddPlayer.xaml"
            this.PlayerGoals.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalInputValidation);
            
            #line default
            #line hidden
            return;
            case 10:
            this.PlayerAssists = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\AddPlayer.xaml"
            this.PlayerAssists.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalInputValidation);
            
            #line default
            #line hidden
            return;
            case 11:
            this.PlayerJerseyNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 61 "..\..\..\AddPlayer.xaml"
            this.PlayerJerseyNumber.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumericalInputValidation);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 84 "..\..\..\AddPlayer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddPlayerSaveChanges);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

