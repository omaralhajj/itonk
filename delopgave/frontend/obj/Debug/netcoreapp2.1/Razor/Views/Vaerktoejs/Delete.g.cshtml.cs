#pragma checksum "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ab757a9c5f63683a15886e6e0a920a7f36a277c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vaerktoejs_Delete), @"mvc.1.0.view", @"/Views/Vaerktoejs/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vaerktoejs/Delete.cshtml", typeof(AspNetCore.Views_Vaerktoejs_Delete))]
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
#line 1 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\_ViewImports.cshtml"
using frontend;

#line default
#line hidden
#line 2 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\_ViewImports.cshtml"
using frontend.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab757a9c5f63683a15886e6e0a920a7f36a277c", @"/Views/Vaerktoejs/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f624b776dbc42c2a9159e0f68d7420eb755c6e4e", @"/Views/_ViewImports.cshtml")]
    public class Views_Vaerktoejs_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<frontend.Models.Vaerktoej>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(33, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(73, 161, true);
            WriteLiteral("\n<h2>Delete</h2>\n\n<h3>Are you sure you want to delete this?</h3>\n<div>\n    <h4>Vaerktoej</h4>\n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n            ");
            EndContext();
            BeginContext(235, 46, false);
#line 15 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.LiggerIvkt));

#line default
#line hidden
            EndContext();
            BeginContext(281, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(322, 42, false);
#line 18 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.LiggerIvkt));

#line default
#line hidden
            EndContext();
            BeginContext(364, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(405, 47, false);
#line 21 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VtAnskaffet));

#line default
#line hidden
            EndContext();
            BeginContext(452, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(493, 43, false);
#line 24 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VtAnskaffet));

#line default
#line hidden
            EndContext();
            BeginContext(536, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(577, 46, false);
#line 27 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VtFabrikat));

#line default
#line hidden
            EndContext();
            BeginContext(623, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(664, 42, false);
#line 30 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VtFabrikat));

#line default
#line hidden
            EndContext();
            BeginContext(706, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(747, 43, false);
#line 33 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VtModel));

#line default
#line hidden
            EndContext();
            BeginContext(790, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(831, 39, false);
#line 36 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VtModel));

#line default
#line hidden
            EndContext();
            BeginContext(870, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(911, 45, false);
#line 39 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VtSerienr));

#line default
#line hidden
            EndContext();
            BeginContext(956, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(997, 41, false);
#line 42 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VtSerienr));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 40, true);
            WriteLiteral("\n        </dd>\n        <dt>\n            ");
            EndContext();
            BeginContext(1079, 42, false);
#line 45 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.VtType));

#line default
#line hidden
            EndContext();
            BeginContext(1121, 40, true);
            WriteLiteral("\n        </dt>\n        <dd>\n            ");
            EndContext();
            BeginContext(1162, 38, false);
#line 48 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
       Write(Html.DisplayFor(model => model.VtType));

#line default
#line hidden
            EndContext();
            BeginContext(1200, 34, true);
            WriteLiteral("\n        </dd>\n    </dl>\n    \n    ");
            EndContext();
            BeginContext(1234, 205, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7fd761a0e3e847f3a597112aa5c15b16", async() => {
                BeginContext(1260, 9, true);
                WriteLiteral("\n        ");
                EndContext();
                BeginContext(1269, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cb058d45ddae4c4ca70f82c4548a3f31", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 53 "C:\Users\Omar\Desktop\itonk\delopgave\frontend\Views\Vaerktoejs\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VtId);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1307, 82, true);
                WriteLiteral("\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\n        ");
                EndContext();
                BeginContext(1389, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "464fcc2dfd4e4ea085f9859d8e2666ef", async() => {
                    BeginContext(1411, 12, true);
                    WriteLiteral("Back to List");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
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
                BeginContext(1427, 5, true);
                WriteLiteral("\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1439, 8, true);
            WriteLiteral("\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<frontend.Models.Vaerktoej> Html { get; private set; }
    }
}
#pragma warning restore 1591
