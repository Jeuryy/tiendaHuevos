﻿#pragma checksum "..\..\..\Views\Usuarios.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "63CBEA8DB68CA6EC863D0CEAF3D62921ECAEAF43323D1C713608E5EFD8543D67"
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
using eggstore.Views;


namespace eggstore.Views {
    
    
    /// <summary>
    /// Usuarios
    /// </summary>
    public partial class Usuarios : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 220 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridUsuarios;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Contenido;
        
        #line default
        #line hidden
        
        
        #line 275 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbBuscar;
        
        #line default
        #line hidden
        
        
        #line 284 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCrearUsuario;
        
        #line default
        #line hidden
        
        
        #line 300 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridDatos;
        
        #line default
        #line hidden
        
        
        #line 387 "..\..\..\Views\Usuarios.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame frameUsuarios;
        
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
            System.Uri resourceLocater = new System.Uri("/eggstore;component/views/usuarios.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\Usuarios.xaml"
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
            this.gridUsuarios = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Contenido = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.tbBuscar = ((System.Windows.Controls.TextBox)(target));
            
            #line 274 "..\..\..\Views\Usuarios.xaml"
            this.tbBuscar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Buscando);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCrearUsuario = ((System.Windows.Controls.Button)(target));
            
            #line 285 "..\..\..\Views\Usuarios.xaml"
            this.btnCrearUsuario.Click += new System.Windows.RoutedEventHandler(this.Agregar);
            
            #line default
            #line hidden
            return;
            case 5:
            this.gridDatos = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.frameUsuarios = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 6:
            
            #line 327 "..\..\..\Views\Usuarios.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Consultar);
            
            #line default
            #line hidden
            break;
            case 7:
            
            #line 338 "..\..\..\Views\Usuarios.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Actualizar);
            
            #line default
            #line hidden
            break;
            case 8:
            
            #line 347 "..\..\..\Views\Usuarios.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Eliminar);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

