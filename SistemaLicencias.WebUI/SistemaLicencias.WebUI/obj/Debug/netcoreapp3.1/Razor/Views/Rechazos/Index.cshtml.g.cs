#pragma checksum "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "517ccdc9e257ddd6d5b8af943172b1ca6c62ab19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Rechazos_Index), @"mvc.1.0.view", @"/Views/Rechazos/Index.cshtml")]
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
#line 1 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\_ViewImports.cshtml"
using SistemaLicencias.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\_ViewImports.cshtml"
using SistemaLicencias.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"517ccdc9e257ddd6d5b8af943172b1ca6c62ab19", @"/Views/Rechazos/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d23932c8a5a08be6d1e44b6ca0df25c912b453f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Rechazos_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaLicencias.WebUI.Models.VWRechazadosViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/App/Licencias/Rechazado.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<input hidden id=\"resultado\"");
            BeginWriteAttribute("value", " value=\"", 195, "\"", 221, 1);
#nullable restore
#line 9 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
WriteAttributeValue("", 203, ViewBag.Resultado, 203, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

<div class=""card"" style=""border:1px solid #283c4c;"">
    <div class=""card-header text-center"" style=""background: radial-gradient(circle, rgba(30,45,93,1) 50%, rgba(32,164,140,1) 100%); "">

        <div class=""row"">
            <div class=""col"">
                <h1 class=""text-white"" style=""margin-top:0px;"">Solocitudes Rechazadas</h1>
            </div>
        </div>
        <div class=""row d-flex justify-content-center"">
            <div class=""col-4"">
");
            WriteLiteral(@"            </div>
        </div>

    </div>
    <div class=""card-body table-responsive"">
        <table class=""table table-hover dataTables"">
            <thead style=background-color: transparent;>
                <tr>
                    <th>
                        ");
#nullable restore
#line 34 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.stud_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 37 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.soli_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 40 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.soli_Identidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 43 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.soli_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 46 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 49 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.sucu_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 52 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 58 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.stud_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.soli_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.soli_Identidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 71 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.soli_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 77 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.sucu_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 80 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 83 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                       Write(Html.ActionLink("Details", "Details", new { id = item.stud_Id }, new { @class = "btn btn-info mx-1 btn-outline btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 86 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Rechazos\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "517ccdc9e257ddd6d5b8af943172b1ca6c62ab1912217", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaLicencias.WebUI.Models.VWRechazadosViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
