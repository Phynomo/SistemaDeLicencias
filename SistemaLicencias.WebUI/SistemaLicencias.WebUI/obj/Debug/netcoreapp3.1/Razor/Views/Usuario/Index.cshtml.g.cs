#pragma checksum "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8cedb0ba00ef5f1ccf23049e59746987f0a0056c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Index), @"mvc.1.0.view", @"/Views/Usuario/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8cedb0ba00ef5f1ccf23049e59746987f0a0056c", @"/Views/Usuario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d23932c8a5a08be6d1e44b6ca0df25c912b453f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaLicencias.WebUI.Models.VWUsuarioViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/switches.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/App/Seguridad/Usuario.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8cedb0ba00ef5f1ccf23049e59746987f0a0056c4705", async() => {
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
            BeginWriteAttribute("value", " value=\"", 245, "\"", 271, 1);
#nullable restore
#line 10 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 253, ViewBag.Resultado, 253, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />

<div class=""card"" style=""border:1px solid #283c4c;"">
    <div class=""card-header text-center"" style=""background: radial-gradient(circle, rgba(30,45,93,1) 50%, rgba(32,164,140,1) 100%); "">

        <div class=""row"">
            <div class=""col"">
                <h1 class=""text-white"" style=""margin-top:0px;"">Usuarios</h1>
            </div>
        </div>
        <div class=""row d-flex justify-content-center"">
            <div class=""col-4"">
                <button onclick=""OpenModalCreate()"" type=""button"" class=""btn btn-block btn-primary"">
                    Agregar
                </button>
            </div>
        </div>
    </div>
    <div class=""card-body table-responsive"">
        <table class=""table table-hover dataTables"" data-filtering=""true"">
            <thead style=background-color: transparent;>
                <tr>
                    <th>
                        ");
#nullable restore
#line 33 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 36 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th>\r\n                        ");
#nullable restore
#line 40 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_EsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 43 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.role_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 46 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 53 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 57 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 60 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 64 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_EsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 68 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.role_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 71 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <button class=\"btn btn-warning btn-sm  btn-outline\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2809, "\"", 2898, 9);
            WriteAttributeValue("", 2819, "Editar(\'", 2819, 8, true);
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2827, item.user_Id, 2827, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2840, ",$$,", 2840, 4, true);
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2844, item.user_EsAdmin, 2844, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2862, ",$$,", 2862, 4, true);
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2866, item.role_Id, 2866, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2879, ",$$,", 2879, 4, true);
#nullable restore
#line 74 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2883, item.empe_Id, 2883, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2896, "\')", 2896, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n                            ");
#nullable restore
#line 75 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.ActionLink("Detalles", "Details", new { id = item.user_Id }, new { @class = "btn btn-info mx-1 btn-outline btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <button class=\"btn btn-danger btn-sm btn-outline\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3161, "\"", 3203, 3);
            WriteAttributeValue("", 3171, "OpenModalDelete(\'", 3171, 17, true);
#nullable restore
#line 76 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 3188, item.user_Id, 3188, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3201, "\')", 3201, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Eliminar</button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 79 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 86 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_CreateViewPartial", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 87 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_DeleteViewPartial", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 88 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_EditPartialView", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8cedb0ba00ef5f1ccf23049e59746987f0a0056c15932", async() => {
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
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SistemaLicencias.WebUI.Models.VWUsuarioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
