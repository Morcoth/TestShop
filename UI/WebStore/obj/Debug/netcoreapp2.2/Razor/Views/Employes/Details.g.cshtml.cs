#pragma checksum "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Employes\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8d8cafc1dee02aa7abe62172ba4821781b0a51b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employes_Details), @"mvc.1.0.view", @"/Views/Employes/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Employes/Details.cshtml", typeof(AspNetCore.Views_Employes_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8d8cafc1dee02aa7abe62172ba4821781b0a51b", @"/Views/Employes/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"228c31f8671c7c0474bea7787e176e186c8e3314", @"/Views/_ViewImports.cshtml")]
    public class Views_Employes_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebStore.Domain.Models.Employee>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Employes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 69, true);
            WriteLiteral("\r\n<h3>Карточка сотрдуника</h3>\r\n\r\n<div>\r\n    <p>Фамилия:</p>\r\n    <p>");
            EndContext();
            BeginContext(110, 13, false);
#line 7 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Employes\Details.cshtml"
  Write(Model.SurName);

#line default
#line hidden
            EndContext();
            BeginContext(123, 47, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div>\r\n    <p>Имя:</p>\r\n    <p>");
            EndContext();
            BeginContext(171, 15, false);
#line 12 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Employes\Details.cshtml"
  Write(Model.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(186, 52, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div>\r\n    <p>Отчество:</p>\r\n    <p>");
            EndContext();
            BeginContext(239, 16, false);
#line 17 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Employes\Details.cshtml"
  Write(Model.Patronymic);

#line default
#line hidden
            EndContext();
            BeginContext(255, 51, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div>\r\n    <p>Возраст:</p>\r\n    <p>");
            EndContext();
            BeginContext(307, 9, false);
#line 22 "D:\ASP\AspFromGeekBrainss\UI\WebStore\Views\Employes\Details.cshtml"
  Write(Model.Age);

#line default
#line hidden
            EndContext();
            BeginContext(316, 26, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<hr />\r\n\r\n");
            EndContext();
            BeginContext(342, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8d8cafc1dee02aa7abe62172ba4821781b0a51b5050", async() => {
                BeginContext(390, 20, true);
                WriteLiteral("К списку сотрудников");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebStore.Domain.Models.Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
