﻿#pragma checksum "..\..\..\Component\HlpDatePicker.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "036909F735FA93EE2CB80EF034C27AB6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HLP.Controls.Base;
using HLP.Controls.Converters.Component;
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
    /// HlpDatePicker
    /// </summary>
    public partial class HlpDatePicker : HLP.Controls.Base.UserControlBase, System.Windows.Markup.IComponentConnector {
        
        
        #line 104 "..\..\..\Component\HlpDatePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock compBlock;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Component\HlpDatePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDate;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Component\HlpDatePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTime;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\Component\HlpDatePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCalendar;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\..\Component\HlpDatePicker.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup mainCalendar;
        
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
            System.Uri resourceLocater = new System.Uri("/HLP.Controls;component/component/hlpdatepicker.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Component\HlpDatePicker.xaml"
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
            this.compBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.txtDate = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtTime = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnCalendar = ((System.Windows.Controls.Button)(target));
            
            #line 130 "..\..\..\Component\HlpDatePicker.xaml"
            this.btnCalendar.Click += new System.Windows.RoutedEventHandler(this.btnCalendar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mainCalendar = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 6:
            
            #line 136 "..\..\..\Component\HlpDatePicker.xaml"
            ((System.Windows.Controls.Calendar)(target)).SelectedDatesChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.Calendar_SelectedDatesChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

