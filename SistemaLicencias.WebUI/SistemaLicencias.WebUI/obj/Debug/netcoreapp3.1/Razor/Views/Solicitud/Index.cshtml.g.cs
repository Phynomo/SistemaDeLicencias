#pragma checksum "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ddb90d70c795b96ee1785feec4f7c270ea6b37e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Solicitud_Index), @"mvc.1.0.view", @"/Views/Solicitud/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ddb90d70c795b96ee1785feec4f7c270ea6b37e", @"/Views/Solicitud/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d23932c8a5a08be6d1e44b6ca0df25c912b453f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Solicitud_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaLicencias.WebUI.Models.VWSolicitudViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/switches.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/App/Licencias/Solicitud.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8ddb90d70c795b96ee1785feec4f7c270ea6b37e4721", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<input hidden id=\"resultado\"");
            BeginWriteAttribute("value", " value=\"", 247, "\"", 273, 1);
#nullable restore
#line 10 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 255, ViewBag.Resultado, 255, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

<div class=""card"" style=""border:1px solid #283c4c;"">
    <div class=""card-header text-center"" style=""background: radial-gradient(circle, rgba(30,45,93,1) 50%, rgba(32,164,140,1) 100%); "">

        <div class=""row"">
            <div class=""col"">
                <h1 class=""text-white"" style=""margin-top:0px;"">Solicitud</h1>
            </div>
        </div>
        <div class=""row d-flex justify-content-center"">
            <div class=""col-4"">
                <button onclick=""OpenModalCreate()"" type=""button"" class=""btn btn-block btn-primary"">
                    Agregar
                </button>

");
            WriteLiteral(@"            </div>
        </div>
    </div>
    <div class=""card-body table-responsive"">
        <table class=""table table-hover dataTables"" data-filtering=""true"">
            <thead style=background-color: transparent;>
                <tr>
                    <th>
                        ");
#nullable restore
#line 35 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.soli_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 38 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.sucu_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 41 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 44 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.stud_Pago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 52 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>  \r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.soli_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.sucu_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.stud_Pago));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <button class=\"btn btn-warning btn-sm  btn-outline\" type=\"button\" id=\"OpenModalEdit\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2701, "\"", 2804, 11);
            WriteAttributeValue("", 2711, "Editar(\'", 2711, 8, true);
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2719, item.stud_Id, 2719, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2732, ",$$,", 2732, 4, true);
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2736, item.soli_Id, 2736, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2749, ",$$,", 2749, 4, true);
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2753, item.sucu_Id, 2753, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2766, ",$$,", 2766, 4, true);
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2770, item.tili_Id, 2770, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2783, ",$$,", 2783, 4, true);
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 2787, item.stud_Pago, 2787, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2802, "\')", 2802, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n\r\n                            ");
#nullable restore
#line 70 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                       Write(Html.ActionLink("Detalles", "Details", new { id = item.stud_Id }, new { @class = "btn btn-info mx-1 btn-outline btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                            <button class=\"btn btn-danger btn-sm btn-outline\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3071, "\"", 3113, 3);
            WriteAttributeValue("", 3081, "OpenModalDelete(\'", 3081, 17, true);
#nullable restore
#line 72 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 3098, item.stud_Id, 3098, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3111, "\')", 3111, 2, true);
            EndWriteAttribute();
            WriteLiteral(@">Eliminar</button>

                            <div class=""btn-group"">
                                <button data-toggle=""dropdown"" class=""btn btn-secondary btn-sm  btn-outline dropdown-toggle"">Aceptar/Rechazar</button>
                                <ul class=""dropdown-menu"">
                                    <li><a class=""dropdown-item""");
            BeginWriteAttribute("onclick", " onclick=\"", 3465, "\"", 3497, 3);
            WriteAttributeValue("", 3475, "Rejeact(", 3475, 8, true);
#nullable restore
#line 77 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 3483, item.stud_Id, 3483, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3496, ")", 3496, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Rechazar</a></li>\r\n                                    <li><a class=\"dropdown-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3582, "\"", 3613, 3);
            WriteAttributeValue("", 3592, "Accept(", 3592, 7, true);
#nullable restore
#line 78 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
WriteAttributeValue("", 3599, item.stud_Id, 3599, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3612, ")", 3612, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Aceptar</a></li>\r\n                                </ul>\r\n                            </div>\r\n\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 84 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 91 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
Write(Html.Partial("_DeleteViewPartial", new SistemaLicencias.WebUI.Models.SolicitudViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 92 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
Write(Html.Partial("_CreateViewPartial", new SistemaLicencias.WebUI.Models.SolicitudViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 93 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
Write(Html.Partial("_EditViewPartial", new SistemaLicencias.WebUI.Models.SolicitudViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 94 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
Write(Html.Partial("_RejectViewPartial", new SistemaLicencias.WebUI.Models.RechazadosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 95 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Solicitud\Index.cshtml"
Write(Html.Partial("_AcceptViewPartial", new SistemaLicencias.WebUI.Models.AprovadosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8ddb90d70c795b96ee1785feec4f7c270ea6b37e17875", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaLicencias.WebUI.Models.VWSolicitudViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
