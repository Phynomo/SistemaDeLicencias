#pragma checksum "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69d78dc343caf4f61d25fe7ef5593ec304ac9f29"
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
#line 1 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\_ViewImports.cshtml"
using SistemaLicencias.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\_ViewImports.cshtml"
using SistemaLicencias.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69d78dc343caf4f61d25fe7ef5593ec304ac9f29", @"/Views/Usuario/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d23932c8a5a08be6d1e44b6ca0df25c912b453f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaLicencias.WebUI.Models.VWUsuarioViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/App/Seguridad/Usuario.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input hidden id=\"resultado\"");
            BeginWriteAttribute("value", " value=\"", 190, "\"", 216, 1);
#nullable restore
#line 8 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 198, ViewBag.Resultado, 198, 18, false);

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
#line 31 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 34 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th>\r\n                        ");
#nullable restore
#line 38 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.user_EsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 41 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.role_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 44 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 51 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 55 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 58 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_NombreUsuario));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.user_EsAdmin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n                            ");
#nullable restore
#line 66 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.role_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 69 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <button class=\"btn btn-warning btn-sm  btn-outline\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2754, "\"", 2843, 9);
            WriteAttributeValue("", 2764, "Editar(\'", 2764, 8, true);
#nullable restore
#line 72 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2772, item.user_Id, 2772, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2785, ",$$,", 2785, 4, true);
#nullable restore
#line 72 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2789, item.user_EsAdmin, 2789, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2807, ",$$,", 2807, 4, true);
#nullable restore
#line 72 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2811, item.role_Id, 2811, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2824, ",$$,", 2824, 4, true);
#nullable restore
#line 72 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 2828, item.empe_Id, 2828, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2841, "\')", 2841, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button>\r\n                            ");
#nullable restore
#line 73 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                       Write(Html.ActionLink("Detalles", "Details", new { id = item.user_Id }, new { @class = "btn btn-info mx-1 btn-outline btn-sm" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            <button class=\"btn btn-danger btn-sm btn-outline\" type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3106, "\"", 3148, 3);
            WriteAttributeValue("", 3116, "OpenModalDelete(\'", 3116, 17, true);
#nullable restore
#line 74 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
WriteAttributeValue("", 3133, item.user_Id, 3133, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3146, "\')", 3146, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Eliminar</button>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 77 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
#nullable restore
#line 84 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_CreateViewPartial", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 85 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_DeleteViewPartial", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 86 "C:\Users\danie\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Usuario\Index.cshtml"
Write(Html.Partial("_EditPartialView", new SistemaLicencias.WebUI.Models.UsuariosViewModel()));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "69d78dc343caf4f61d25fe7ef5593ec304ac9f2914108", async() => {
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
