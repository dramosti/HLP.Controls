﻿#pragma checksum "..\..\..\Component\FindImage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3481D5A655ABE576BA7B1904A46583EA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.33440
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HLP.Controls.Base;
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


namespace HLP.Controls.Component {
    
    
    /// <summary>
    /// FindImage
    /// </summary>
    public partial class FindImage : HLP.Controls.Base.UserControlBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HLP.Controls.Component.FindImage uc;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock compBlock;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gdContainer;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPath;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnFind;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\Component\FindImage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup popUpImg;
        
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
            System.Uri resourceLocater = new System.Uri("/HLP.Controls;component/component/findimage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Component\FindImage.xaml"
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
            this.uc = ((HLP.Controls.Component.FindImage)(target));
            return;
            case 2:
            this.compBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.gdContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.txtPath = ((System.Windows.Controls.TextBox)(target));
            
            #line 75 "..\..\..\Component\FindImage.xaml"
            this.txtPath.MouseEnter += new System.Windows.Input.MouseEventHandler(this.txtPath_MouseEnter);
            
            #line default
            #line hidden
            
            #line 76 "..\..\..\Component\FindImage.xaml"
            this.txtPath.MouseLeave += new System.Windows.Input.MouseEventHandler(this.txtPath_MouseLeave);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\Component\FindImage.xaml"
            this.txtPath.GotKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.txtPath_GotKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 78 "..\..\..\Component\FindImage.xaml"
            this.txtPath.LostKeyboardFocus += new System.Windows.Input.KeyboardFocusChangedEventHandler(this.txtPath_LostKeyboardFocus);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Component\FindImage.xaml"
            this.txtPath.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtPath_KeyDown);
            
            #line default
            #line hidden
            
            #line 79 "..\..\..\Component\FindImage.xaml"
            this.txtPath.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtPath_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 84 "..\..\..\Component\FindImage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnFind = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\Component\FindImage.xaml"
            this.btnFind.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.popUpImg = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

