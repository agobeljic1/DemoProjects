#pragma checksum "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36066dc3fec1a999137a2e97a930e98f594ba44b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nalog_PrikazNaloga), @"mvc.1.0.view", @"/Views/Nalog/PrikazNaloga.cshtml")]
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
#nullable restore
#line 1 "C:\ADNAN\ETF\Elevate\Elevate\Views\_ViewImports.cshtml"
using Elevate;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ADNAN\ETF\Elevate\Elevate\Views\_ViewImports.cshtml"
using Elevate.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
using Elevate.Models.DatabaseKlase;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36066dc3fec1a999137a2e97a930e98f594ba44b", @"/Views/Nalog/PrikazNaloga.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8afcb2e83dc798c96ef4b3fa2214192c4fa056", @"/Views/_ViewImports.cshtml")]
    public class Views_Nalog_PrikazNaloga : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Nalog>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight: bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Automobili", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PrikazAuta", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
  
    ViewBag.Title = "Nalog";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <section>\r\n            <h2>");
#nullable restore
#line 16 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
           Write(ViewBag.Data.Auto.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <hr />\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b5261", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 19 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Auto);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b6756", async() => {
#nullable restore
#line 19 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                                                                                                          Write(ViewBag.Data.Auto.Model);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-autoId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                                                                                  WriteLiteral(ViewBag.Data.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["autoId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-autoId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["autoId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b9807", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 22 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ImePrezimeVozaca);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 22 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                 Write(ViewBag.Data.ImePrezimeVozaca);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b11691", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 25 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VrijemePocetak);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 25 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                               Write(ViewBag.Data.VrijemePocetak);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b13570", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 28 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VrijemeKraj);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 28 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                            Write(ViewBag.Data.VrijemeKraj);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b15440", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 31 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.PolaznaLokacija);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 31 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                Write(ViewBag.Data.PolaznaLokacija);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b17322", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 34 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.DolaznaLokacija);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 34 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                Write(ViewBag.Data.DolaznaLokacija);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b19204", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 37 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BrojPutnikaUAutomobilu);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 37 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                                       Write(ViewBag.Data.BrojPutnikaUAutomobilu);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36066dc3fec1a999137a2e97a930e98f594ba44b21107", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 40 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NalogStatus);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(": ");
#nullable restore
#line 40 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                                                            Write(ViewBag.Data.NalogStatus.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>


        </section>
    </div>
    <div class=""col-md-8"">
        <section>
            <div style=""width: 100%"">
                <h2 style=""display: inline-block"">Promjena statusa</h2>

            </div>

            <hr />

            Nalog se može naći u sljedećim statusima:
            <ol>
                <li>Evidentiran - Nalog nakon kreiranja prelazi u stanje Evidentiran</li>
                <li>Potrvđen - Nakon preuzimanja vozila, nalog prelazi u stanje Potvrđen</li>
                <li>Odbijen - Ako se preuzimanje neće dogoditi. nalog prelazi u stanje Odbijen </li>
                <li>Završen - Vraćanjem preuzetog vozila, nalog prelazi u stanje Završen</li>
            </ol>
            Trenutno je nalog u statusu ");
#nullable restore
#line 62 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                                   Write(ViewBag.Data.NalogStatus.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <br />\r\n\r\n");
#nullable restore
#line 65 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
             if (ViewBag.Data.NalogStatus.Id == 4)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Nalog je završen. Ne možete mijenjati njegov status.</p>\r\n");
#nullable restore
#line 68 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <p>Odaberite novi status:</p>\r\n");
#nullable restore
#line 72 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"

                if (ViewBag.Data.NalogStatus.Id == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div style=""display: inline-block; width: 100%; margin-bottom: 2vh"">
                        <button type=""button"" class=""btn btn-danger"" data-toggle=""modal"" data-target=""#BootstrapModalId3"">Odbijen</button>
                        <button style=""float:right"" type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#BootstrapModalId2"">Potvrđen</button>
                    </div>
");
#nullable restore
#line 79 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                }
                else if(ViewBag.Data.NalogStatus.Id == 3)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div style=""display: inline-block; width: 100%; margin-bottom: 2vh"">
                        <button style=""float:right"" type=""button"" class=""btn btn-success"" data-toggle=""modal"" data-target=""#BootstrapModalId2"">Potvrđen</button>
                    </div>
");
#nullable restore
#line 85 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div style=""display: inline-block; width: 100%; margin-bottom: 2vh"">
                        <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#BootstrapModalId4"">Završen</button>
                    </div>
");
#nullable restore
#line 91 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"

                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </section>
    </div>
</div>
<div id=""BootstrapModalId2"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">

            <div class=""modal-body"">
                Da li ste sigurni da želite potvrditi nalog?
            </div>
            <div class=""modal-footer"">
                ");
#nullable restore
#line 106 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
           Write(Html.ActionLink("Potvrdi", "PromijeniNalog", "Nalog", new { nalogId = ViewBag.Data.Id, nalogStatusId = 2 }, new { @class = "btn btn-primary btn-update" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Nazad</button>
            </div>
        </div>
    </div>
</div>
<div id=""BootstrapModalId3"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">

            <div class=""modal-body"">
                Da li ste sigurni da želite odbiti nalog?
            </div>
            <div class=""modal-footer"">
                ");
#nullable restore
#line 122 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
           Write(Html.ActionLink("Potvrdi", "PromijeniNalog", "Nalog", new { nalogId = ViewBag.Data.Id, nalogStatusId = 3 }, new { @class = "btn btn-primary btn-update" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Nazad</button>
            </div>
        </div>
    </div>
</div>

<div id=""BootstrapModalId4"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">

            <div class=""modal-body"">
                Da li ste sigurni da želite završiti nalog?
            </div>
            <div class=""modal-footer"">
                ");
#nullable restore
#line 139 "C:\ADNAN\ETF\Elevate\Elevate\Views\Nalog\PrikazNaloga.cshtml"
           Write(Html.ActionLink("Potvrdi", "PromijeniNalog", "Nalog", new { nalogId = ViewBag.Data.Id, nalogStatusId = 4 }, new { @class = "btn btn-primary btn-update" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Nazad</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Nalog> Html { get; private set; }
    }
}
#pragma warning restore 1591
