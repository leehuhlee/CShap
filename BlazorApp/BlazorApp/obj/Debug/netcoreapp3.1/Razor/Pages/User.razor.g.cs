#pragma checksum "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da65350ce8ffad22501a3bff37f4017fe189e178"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
using BlazorApp.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/user")]
    public partial class User : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>Online User</h3>\r\n\r\n");
            __builder.AddMarkupContent(1, "<label>Theme Color:</label>\r\n");
            __builder.OpenElement(2, "select");
            __builder.AddAttribute(3, "class", "form-control");
            __builder.AddAttribute(4, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 7 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                    _selectedColor

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _selectedColor = __value, _selectedColor));
            __builder.SetUpdatesAttributeName("value");
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 8 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
     foreach(var option in _options)
    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "        ");
            __builder.OpenElement(8, "option");
            __builder.AddAttribute(9, "value", 
#nullable restore
#line 10 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                        option

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(10, "\r\n            ");
            __builder.AddContent(11, 
#nullable restore
#line 11 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
             option

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(12, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n");
#nullable restore
#line 13 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(14, "\r\n\r\n");
            __Blazor.BlazorApp.Pages.User.TypeInference.CreateCascadingValue_0(__builder, 15, 16, "ThemeColor", 17, 
#nullable restore
#line 16 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                         _selectedColor

#line default
#line hidden
#nullable disable
            , 18, (__builder2) => {
                __builder2.AddMarkupContent(19, "\r\n    ");
                __builder2.OpenComponent<BlazorApp.Pages.ShowUser>(20);
                __builder2.AddAttribute(21, "Users", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.List<BlazorApp.Data.UserData>>(
#nullable restore
#line 17 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                     _users

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "CallbackTest", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 17 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                           CallbackTestFunc

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddComponentReferenceCapture(23, (__value) => {
#nullable restore
#line 17 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                                                   _showUser = (BlazorApp.Pages.ShowUser)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(24, "\r\n");
            }
            );
            __builder.AddMarkupContent(25, "\r\n<br>\r\n\r\n");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "container");
            __builder.AddMarkupContent(28, "\r\n    ");
            __builder.OpenElement(29, "div");
            __builder.AddAttribute(30, "class", "row");
            __builder.AddMarkupContent(31, "\r\n        ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "col");
            __builder.AddMarkupContent(34, "\r\n            ");
            __builder.OpenElement(35, "input");
            __builder.AddAttribute(36, "class", "form-control");
            __builder.AddAttribute(37, "placeholder", "Add User");
            __builder.AddAttribute(38, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 24 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                                                           _inputName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(39, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => _inputName = __value, _inputName));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n        ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "col");
            __builder.AddMarkupContent(44, "\r\n            ");
            __builder.OpenElement(45, "button");
            __builder.AddAttribute(46, "class", "btn btn-primary");
            __builder.AddAttribute(47, "type", "button");
            __builder.AddAttribute(48, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                                                    AddUser

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(49, "disabled", 
#nullable restore
#line 27 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
                                                                                         _users.Count()>=5

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(50, "Add a User");
            __builder.CloseElement();
            __builder.AddMarkupContent(51, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 32 "C:\Users\leehu\Desktop\CShap\BlazorApp\BlazorApp\Pages\User.razor"
       

    string _selectedColor = "Green";
    List<string> _options = new List<string>() { "Green", "Red", "Blue" };

    List<UserData> _users = new List<UserData>();
    ShowUser _showUser;

    string _inputName;

    void AddUser()
    {
        _showUser.AddUser(new UserData() { Name = _inputName });
        _inputName = "";
    }

    void KickUser(UserData user)
    {
        _showUser.KickUser(user);
    }

    void CallbackTestFunc()
    {
        _inputName = "CallbackTest";
    }


#line default
#line hidden
#nullable disable
    }
}
namespace __Blazor.BlazorApp.Pages.User
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateCascadingValue_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TValue __arg1, int __seq2, global::Microsoft.AspNetCore.Components.RenderFragment __arg2)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Name", __arg0);
        __builder.AddAttribute(__seq1, "Value", __arg1);
        __builder.AddAttribute(__seq2, "ChildContent", __arg2);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
