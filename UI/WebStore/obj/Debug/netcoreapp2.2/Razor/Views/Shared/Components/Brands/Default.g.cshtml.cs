#pragma checksum "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Brands\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5de87e52be366a41657feebb16b54189b4a6553"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Brands_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Brands/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Brands/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Brands_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5de87e52be366a41657feebb16b54189b4a6553", @"/Views/Shared/Components/Brands/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228c31f8671c7c0474bea7787e176e186c8e3314", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Brands_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebStore.Domain.ViewModels.Product.BrandViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 161, true);
            WriteLiteral("\r\n<div class=\"brands_products\">\r\n    <!--brands_products-->\r\n    <h2>Бренды</h2>\r\n    <div class=\"brands-name\">\r\n        <ul class=\"nav nav-pills nav-stacked\">\r\n");
            EndContext();
#line 8 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Brands\Default.cshtml"
             foreach (var brand in Model)
            {

#line default
#line hidden
            BeginContext(290, 59, true);
            WriteLiteral("                <li><a href=\"#\"> <span class=\"pull-right\">(");
            EndContext();
            BeginContext(350, 19, false);
#line 10 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Brands\Default.cshtml"
                                                      Write(brand.ProductsCount);

#line default
#line hidden
            EndContext();
            BeginContext(369, 8, true);
            WriteLiteral(")</span>");
            EndContext();
            BeginContext(378, 10, false);
#line 10 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Brands\Default.cshtml"
                                                                                  Write(brand.Name);

#line default
#line hidden
            EndContext();
            BeginContext(388, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 11 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Brands\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(414, 56, true);
            WriteLiteral("        </ul>\r\n    </div>\r\n</div><!--/brands_products-->");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebStore.Domain.ViewModels.Product.BrandViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
