#pragma checksum "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "769ac529b604525626048408a2dd6dd2f4f12f70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"769ac529b604525626048408a2dd6dd2f4f12f70", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228c31f8671c7c0474bea7787e176e186c8e3314", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Главная страница";
    Layout = "_LayoutBase";

#line default
#line hidden
            BeginContext(77, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(80, 42, false);
#line 6 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml"
Write(await Html.PartialAsync("Partial/_Slider"));

#line default
#line hidden
            EndContext();
            BeginContext(122, 123, true);
            WriteLiteral("\r\n\r\n<section>\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-3\">\r\n                ");
            EndContext();
            BeginContext(246, 47, false);
#line 12 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("Partial/_LeftSideBar"));

#line default
#line hidden
            EndContext();
            BeginContext(293, 90, true);
            WriteLiteral("\r\n            </div>\r\n\r\n            <div class=\"col-sm-9 padding-right\">\r\n                ");
            EndContext();
            BeginContext(384, 47, false);
#line 16 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("Partial/_CategoryTab"));

#line default
#line hidden
            EndContext();
            BeginContext(431, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(450, 51, false);
#line 17 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Home\Index.cshtml"
           Write(await Html.PartialAsync("Partial/_RecomendedItems"));

#line default
#line hidden
            EndContext();
            BeginContext(501, 64, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(584, 85, true);
                WriteLiteral("\r\n    <script>\r\n        $(\"section\").click(function() {\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(672, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(692, 39, true);
                WriteLiteral("\r\n    <style>\r\n        \r\n    </style>\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
