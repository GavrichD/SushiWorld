﻿#pragma checksum "..\..\InformationWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E3F1C24FC7D12E7A62F525CBF40A855CF9E910F0AF2AFE6B3C9E44F28A7696A3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using SushiWorld;
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


namespace SushiWorld {
    
    
    /// <summary>
    /// InformationWindow
    /// </summary>
    public partial class InformationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Head;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Body;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border HappyBirthdayBanner;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border HappyBirthday;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CoolDaysBanner;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CoolDays;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border goBackButton;
        
        #line default
        #line hidden
        
        
        #line 134 "..\..\InformationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Back;
        
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
            System.Uri resourceLocater = new System.Uri("/SushiWorld;component/informationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\InformationWindow.xaml"
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
            this.Head = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Body = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.HappyBirthdayBanner = ((System.Windows.Controls.Border)(target));
            
            #line 47 "..\..\InformationWindow.xaml"
            this.HappyBirthdayBanner.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ShowText);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HappyBirthday = ((System.Windows.Controls.Border)(target));
            
            #line 70 "..\..\InformationWindow.xaml"
            this.HappyBirthday.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HideText);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CoolDaysBanner = ((System.Windows.Controls.Border)(target));
            
            #line 91 "..\..\InformationWindow.xaml"
            this.CoolDaysBanner.MouseEnter += new System.Windows.Input.MouseEventHandler(this.ShowText);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CoolDays = ((System.Windows.Controls.Border)(target));
            
            #line 109 "..\..\InformationWindow.xaml"
            this.CoolDays.MouseLeave += new System.Windows.Input.MouseEventHandler(this.HideText);
            
            #line default
            #line hidden
            return;
            case 7:
            this.goBackButton = ((System.Windows.Controls.Border)(target));
            
            #line 127 "..\..\InformationWindow.xaml"
            this.goBackButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GoBack);
            
            #line default
            #line hidden
            
            #line 128 "..\..\InformationWindow.xaml"
            this.goBackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.DoFat);
            
            #line default
            #line hidden
            
            #line 129 "..\..\InformationWindow.xaml"
            this.goBackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DoNormal);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Back = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

