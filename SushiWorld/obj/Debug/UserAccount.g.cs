﻿#pragma checksum "..\..\UserAccount.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C073F09050D4118B848DC21C0E17278E40DC7EAEAFC9B351FF85B8DA1F36A8C6"
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
    /// UserAccount
    /// </summary>
    public partial class UserAccount : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Head;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Body;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border goBackButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Back;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border RegistrationPannel;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Ввод_Телефона_Пользователя;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Ввод_Пароля_пользователя;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\UserAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border Регистрация;
        
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
            System.Uri resourceLocater = new System.Uri("/SushiWorld;component/useraccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UserAccount.xaml"
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
            this.goBackButton = ((System.Windows.Controls.Border)(target));
            
            #line 42 "..\..\UserAccount.xaml"
            this.goBackButton.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GoBack);
            
            #line default
            #line hidden
            
            #line 43 "..\..\UserAccount.xaml"
            this.goBackButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.DoFat);
            
            #line default
            #line hidden
            
            #line 44 "..\..\UserAccount.xaml"
            this.goBackButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DoNormal);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Back = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.RegistrationPannel = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.Ввод_Телефона_Пользователя = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            
            #line 72 "..\..\UserAccount.xaml"
            ((System.Windows.Controls.TextBox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.checkEmptyTextBox);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 74 "..\..\UserAccount.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ClearTextBox);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Ввод_Пароля_пользователя = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            
            #line 80 "..\..\UserAccount.xaml"
            ((System.Windows.Controls.TextBox)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.checkEmptyTextBox);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 82 "..\..\UserAccount.xaml"
            ((System.Windows.Controls.TextBlock)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.ClearTextBox);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 89 "..\..\UserAccount.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AuthorizationUser);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Регистрация = ((System.Windows.Controls.Border)(target));
            
            #line 100 "..\..\UserAccount.xaml"
            this.Регистрация.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.GoRegistrationWindow);
            
            #line default
            #line hidden
            
            #line 101 "..\..\UserAccount.xaml"
            this.Регистрация.MouseEnter += new System.Windows.Input.MouseEventHandler(this.DoBig);
            
            #line default
            #line hidden
            
            #line 102 "..\..\UserAccount.xaml"
            this.Регистрация.MouseLeave += new System.Windows.Input.MouseEventHandler(this.DoSmall);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

