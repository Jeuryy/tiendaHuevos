﻿#pragma checksum "..\..\..\..\src\Boxes\Ingresar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "35AB5D625D55DC9F5A7FC656A755AB3310FD4D9758123BDAB44A37E677B42D2B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using eggstore.src.Boxes;


namespace eggstore.src.Boxes {
    
    
    /// <summary>
    /// Ingresar
    /// </summary>
    public partial class Ingresar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 130 "..\..\..\..\src\Boxes\Ingresar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbcantidad;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\..\src\Boxes\Ingresar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\..\..\src\Boxes\Ingresar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancelar;
        
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
            System.Uri resourceLocater = new System.Uri("/eggstore;component/src/boxes/ingresar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\src\Boxes\Ingresar.xaml"
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
            this.tbcantidad = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\..\..\src\Boxes\Ingresar.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.Ok);
            
            #line default
            #line hidden
            return;
            case 3:
            this.BtnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\..\src\Boxes\Ingresar.xaml"
            this.BtnCancelar.Click += new System.Windows.RoutedEventHandler(this.Cancelar);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

