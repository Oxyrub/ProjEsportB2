﻿#pragma checksum "..\..\EditWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AAA6361DB1121F2A46543C0DE2EB7ACB2CA2FD19"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfApp1;


namespace WpfApp1 {
    
    
    /// <summary>
    /// EditWindow
    /// </summary>
    public partial class EditWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Title;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label SubTitle;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxMatchs;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Editor1;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Equipe1;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Score1;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Editor2;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Equipe2;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Score2;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartButton;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\EditWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ValideButton;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/editwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditWindow.xaml"
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
            this.Title = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.SubTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.ListBoxMatchs = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.Editor1 = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.Equipe1 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.Score1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 80 "..\..\EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Moins1);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 81 "..\..\EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Plus1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Editor2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.Equipe2 = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.Score2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            
            #line 99 "..\..\EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Moins2);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 100 "..\..\EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Plus2);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 114 "..\..\EditWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RetourOnClick);
            
            #line default
            #line hidden
            return;
            case 15:
            this.StartButton = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\EditWindow.xaml"
            this.StartButton.Click += new System.Windows.RoutedEventHandler(this.StratTournoi);
            
            #line default
            #line hidden
            return;
            case 16:
            this.ValideButton = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\EditWindow.xaml"
            this.ValideButton.Click += new System.Windows.RoutedEventHandler(this.SaveScore);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

