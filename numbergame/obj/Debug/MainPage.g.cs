﻿

#pragma checksum "D:\Project WinDev\my projects\gameX\FruitSwiper New\FruitSwiper\numbergame\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "87CA01D4C6A33187985D6BD91170EAA1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace numbergame
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 10 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyUp += this.Grid_KeyUp;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 42 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.buttonStart_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 43 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).DataContextChanged += this.comboboxLavel_DataContextChanged_1;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 94 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ToggleSwitch)(target)).Toggled += this.onsb_Toggled;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 96 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.button_up_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 97 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.button_left_Click;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 98 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.button_right_Click;
                 #line default
                 #line hidden
                break;
            case 8:
                #line 99 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.button_down_Click;
                 #line default
                 #line hidden
                break;
            case 9:
                #line 130 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ToggleSwitch)(target)).Toggled += this.sound_b_Toggled;
                 #line default
                 #line hidden
                break;
            case 10:
                #line 104 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.b_help_Click;
                 #line default
                 #line hidden
                break;
            case 11:
                #line 112 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.b_about_Click;
                 #line default
                 #line hidden
                break;
            case 12:
                #line 120 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.b_exit_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

