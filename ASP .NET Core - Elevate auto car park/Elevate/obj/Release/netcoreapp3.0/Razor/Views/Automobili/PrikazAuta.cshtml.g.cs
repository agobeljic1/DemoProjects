#pragma checksum "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71fd54b02842cb705e9ee05fd62590f5204dbda0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Automobili_PrikazAuta), @"mvc.1.0.view", @"/Views/Automobili/PrikazAuta.cshtml")]
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
#line 2 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
using Elevate.Models.DatabaseKlase;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71fd54b02842cb705e9ee05fd62590f5204dbda0", @"/Views/Automobili/PrikazAuta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8afcb2e83dc798c96ef4b3fa2214192c4fa056", @"/Views/_ViewImports.cshtml")]
    public class Views_Automobili_PrikazAuta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Auto>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("font-weight: bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
  
    ViewBag.Title = ViewBag.Data.Model;
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <section>\r\n            <h2>");
#nullable restore
#line 16 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
           Write(ViewBag.Data.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n            <hr />\r\n\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda04255", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 20 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Model);

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
#line 20 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                      Write(ViewBag.Data.Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda06112", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 23 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.GodinaProizvodnje);

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
#line 23 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                                  Write(ViewBag.Data.GodinaProizvodnje);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda08005", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 26 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.VrstaGoriva);

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
#line 26 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                            Write(ViewBag.Data.VrstaGoriva.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda09886", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 29 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SnagaMotora);

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
#line 29 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                            Write(ViewBag.Data.SnagaMotora);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KW (");
#nullable restore
#line 29 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                                                           Write((int)(100 * ViewBag.Data.SnagaMotora * ViewBag.KOLIKO_IMA_KS_U_KW) / 100.0);

#line default
#line hidden
#nullable disable
            WriteLiteral(" KS)\r\n\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda012141", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 33 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BrojSasije);

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
#line 33 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                           Write(ViewBag.Data.BrojSasije);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "71fd54b02842cb705e9ee05fd62590f5204dbda014014", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 36 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.BrojMotora);

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
#line 36 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                                                                           Write(ViewBag.Data.BrojMotora);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n\r\n            <div style=\"display: inline-block; width: 100%; margin-bottom: 2vh\">\r\n                ");
#nullable restore
#line 40 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
           Write(Html.ActionLink("Ažuriraj auto", "AzurirajAuto", "Automobili", new { autoId = ViewBag.Data.Id }, new { @class = "btn btn-primary", @style = "float:right" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                <button type=""button"" class=""btn btn-danger"" data-toggle=""modal"" data-target=""#BootstrapModalId"">Obriši auto</button>

            </div>
        </section>
    </div>
    <div class=""col-md-8"">
        <section>
            <div style=""width: 100%"">
                <h2 style=""display: inline-block"">Historija naloga</h2>
                ");
#nullable restore
#line 51 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
           Write(Html.ActionLink("Kreiraj nalog za ovo auto", "DodajNalog", "Nalog", new { autoId = ViewBag.Data.Id }, new { @class = "btn btn-success", @style = "float:right;vertical-align:top" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


            </div>

            <hr />

            <table id=""myTable"" class=""table table-bordered table-hover"">
                <thead>
                    <tr>
                        <th>Datum početka najma</th>
                        <th>Datum završetka najma</th>
                        <th>Status</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 67 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                     foreach (Nalog item in ViewBag.Data.Nalozi)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr onmouseover=\"this.style.cursor=\'pointer\'\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2742, "\"", 2839, 5);
            WriteAttributeValue("", 2752, "window.location.href", 2752, 20, true);
            WriteAttributeValue(" ", 2772, "=", 2773, 2, true);
            WriteAttributeValue(" ", 2774, "(\'", 2775, 3, true);
#nullable restore
#line 69 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
WriteAttributeValue("", 2777, Url.Action("PrikazNaloga","Nalog", new { nalogID=item.Id }), 2777, 60, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2837, "\')", 2837, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <th>");
#nullable restore
#line 70 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                           Write(item.VrijemePocetak);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 71 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                           Write(item.VrijemeKraj);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <th>");
#nullable restore
#line 72 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                           Write(item.NalogStatus.Naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                        </tr>\r\n");
#nullable restore
#line 74 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>


        </section>
    </div>

    <div id=""BootstrapModalId"" class=""modal"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">

                <div class=""modal-body"">
                    Da li ste sigurni da želite obrisati ovaj automobil?
                </div>
                <div class=""modal-footer"">
                    ");
#nullable restore
#line 90 "C:\ADNAN\ETF\Elevate\Elevate\Views\Automobili\PrikazAuta.cshtml"
               Write(Html.ActionLink("Obriši auto", "ObrisiAuto", "Automobili", new { autoId = ViewBag.Data.Id }, new { @class = "btn btn-danger btn-update" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    <button type=\"button\" class=\"btn btn-secondary\" data-dismiss=\"modal\">Nazad</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $('#myTable').DataTable({
                ""language"": {
                    ""sEmptyTable"": ""Nema naloga za ovaj automobil"",
                    ""sInfo"": ""_START_-_END_ od ukupno _TOTAL_ redova"",
                    ""sInfoEmpty"": ""0-0 od ukupno 0 redova"",
                    ""sInfoFiltered"": """",
                    ""sInfoPostFix"": """",
                    ""sInfoThousands"": "","",
                    ""sLengthMenu"": ""Prikaz _MENU_ redova"",
                    ""sLoadingRecords"": ""Učitavanje..."",
                    ""sProcessing"": ""Procesiranje..."",
                    ""sSearch"": ""Traži:"",
                    ""sZeroRecords"": ""Nema odgovarajućih rezultata"",
                    ""oPaginate"": {
                        ""sFirst"": ""Prva"",
                        ""sLast"": ""Zadnja"",
                        ""sNext"": ""Sljedeća"",
                        ""sPrevious"": ""Prethodna""
                    },
                    ""oAria"": {
          ");
                WriteLiteral(@"              ""sSortAscending"": "": sortiraj kolonu rastuće"",
                        ""sSortDescending"": "": sortiraj kolonu opadajuće""
                    }
                }
            });;//myTable is the id of the table to be displayed as dataTable
            $('div.dataTables_filter label input').css(""display"", ""inline-block"");
            $('div.dataTables_filter label input').css(""width"", ""auto"");
            $('div.dataTables_length label select').css(""display"", ""inline-block"");
            $('div.dataTables_length label select').css(""width"", ""auto"");
        });

    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Auto> Html { get; private set; }
    }
}
#pragma warning restore 1591
