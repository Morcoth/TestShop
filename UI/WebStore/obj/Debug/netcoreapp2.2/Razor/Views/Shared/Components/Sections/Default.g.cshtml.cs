#pragma checksum "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7db108d1fc2cbead9e6da2382f5f7ace8c283c9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Sections_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Sections/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/Sections/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_Sections_Default))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7db108d1fc2cbead9e6da2382f5f7ace8c283c9b", @"/Views/Shared/Components/Sections/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228c31f8671c7c0474bea7787e176e186c8e3314", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Sections_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebStore.Domain.ViewModels.Product.SectionViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(73, 113, true);
            WriteLiteral("<h2>Категории</h2>\r\n\r\n<div class=\"panel-group category-products\" id=\"accordian\">\r\n    <!--category-productsr-->\r\n");
            EndContext();
#line 6 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
     foreach (var parent_section in Model)
    {
        if (parent_section.ChildSections.Count > 0)
        {

#line default
#line hidden
            BeginContext(301, 212, true);
            WriteLiteral("            <div class=\"panel panel-default\">\r\n                <div class=\"panel-heading\">\r\n                    <h4 class=\"panel-title\">\r\n                        <a data-toggle=\"collapse\" data-parent=\"#accordian\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 513, "\"", 539, 2);
            WriteAttributeValue("", 520, "#", 520, 1, true);
#line 13 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
WriteAttributeValue("", 521, parent_section.Id, 521, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(540, 125, true);
            WriteLiteral(">\r\n                            <span class=\"badge pull-right\"><i class=\"fa fa-plus\"></i></span>\r\n                            ");
            EndContext();
            BeginContext(666, 19, false);
#line 15 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
                       Write(parent_section.Name);

#line default
#line hidden
            EndContext();
            BeginContext(685, 103, true);
            WriteLiteral("\r\n                        </a>\r\n                    </h4>\r\n                </div>\r\n                <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 788, "\"", 811, 1);
#line 19 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
WriteAttributeValue("", 793, parent_section.Id, 793, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(812, 111, true);
            WriteLiteral(" class=\"panel-collapse collapse\">\r\n                    <div class=\"panel-body\">\r\n                        <ul>\r\n");
            EndContext();
#line 22 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
                             foreach (var child_section in parent_section.ChildSections)
                            {

#line default
#line hidden
            BeginContext(1044, 48, true);
            WriteLiteral("                                <li><a href=\"#\">");
            EndContext();
            BeginContext(1093, 18, false);
#line 24 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
                                           Write(child_section.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1111, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 25 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
                            }

#line default
#line hidden
            BeginContext(1153, 103, true);
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 30 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(1292, 204, true);
            WriteLiteral("            <div class=\"panel panel-default\">\r\n                <div class=\"panel-heading\">\r\n                    <h4 class=\"panel-title\">\r\n                        <a href=\"#\">\r\n                            ");
            EndContext();
            BeginContext(1497, 19, false);
#line 37 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
                       Write(parent_section.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1516, 103, true);
            WriteLiteral("\r\n                        </a>\r\n                    </h4>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 42 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Shared\Components\Sections\Default.cshtml"
        }
    }

#line default
#line hidden
            BeginContext(1637, 31, true);
            WriteLiteral("</div><!--/category-products-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebStore.Domain.ViewModels.Product.SectionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
