#pragma checksum "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23ab7cb71b417c7620fb691ab2f48d4244345aa0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportes_ReportesRechazos), @"mvc.1.0.view", @"/Views/Reportes/ReportesRechazos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ab7cb71b417c7620fb691ab2f48d4244345aa0", @"/Views/Reportes/ReportesRechazos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d23932c8a5a08be6d1e44b6ca0df25c912b453f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportes_ReportesRechazos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SistemaLicencias.WebUI.Models.VWRechazadosViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/examples/libs/jspdf.umd.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/examples/mitubachi-normal.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/examples/libs/faker.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/jspdf.plugin.autotable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/App/Licencias/Reportes.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
  
    ViewData["Title"] = "ReportesRechazos";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ab7cb71b417c7620fb691ab2f48d4244345aa05561", async() => {
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ab7cb71b417c7620fb691ab2f48d4244345aa06600", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ab7cb71b417c7620fb691ab2f48d4244345aa07639", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ab7cb71b417c7620fb691ab2f48d4244345aa08678", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"


<div class=""card"" style=""border:1px solid #283c4c;"">
    <div class=""card-header text-center"" style=""background: radial-gradient(circle, rgba(30,45,93,1) 50%, rgba(32,164,140,1) 100%); "">

        <div class=""row"">
            <div class=""col"">
                <h1 class=""text-white"" style=""margin-top:0px;"">Rechazos</h1>
            </div>
        </div>
        <div class=""row d-flex justify-content-center"">
            <div class=""col-4"">
                <p class=""text-white"">Reporte de las solicitudes rechzadas</p>
            </div>
        </div>
    </div>

    <div class=""card-body d-flex justify-content-center"">

        <div hidden>

            <table class=""table dataTables"" id=""DataTable"" hidden>
                <thead>
                    <tr>
                        
                        <th>
                            Nombre
                        </th>
                        <th>
                            Apellido
                        </th>
        ");
            WriteLiteral("                <th>\r\n                            Identidad\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 48 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                       Write(Html.DisplayNameFor(model => model.soli_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 51 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                       Write(Html.DisplayNameFor(model => model.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n");
            WriteLiteral("<th>\r\n                            Empleado\r\n                        </th>\r\n");
            WriteLiteral("                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 96 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                           \r\n                            <td>\r\n                                ");
#nullable restore
#line 101 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.soli_Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 104 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.soli_Apellido));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 110 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.soli_Identidad));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 113 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.soli_Sexo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 119 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.tili_Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("<td>\r\n                                ");
#nullable restore
#line 137 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                           Write(Html.DisplayFor(modelItem => item.empe_NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n");
            WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 172 "C:\Users\LAB01\Documents\GitHub\SistemaDeLicencias\SistemaLicencias.WebUI\SistemaLicencias.WebUI\Views\Reportes\ReportesRechazos.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n        <iframe id=\"pdf\" style=\"height:1000px; width:1000px;\"></iframe>\r\n\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23ab7cb71b417c7620fb691ab2f48d4244345aa015603", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    if (!window.jsPDF) window.jsPDF = window.jspdf.jsPDF

    //boton exporta
    $(document).ready(function () {
        // Obtener la tabla por su id
        var tabla = $('#DataTable');

        // Obtener los encabezados de la tabla
        var encabezados = tabla.find('th').map(function (index, element) {
            // Obtener solo las primeras 5 columnas
            return $(element).text();
        }).get();

        // Obtener los datos de la tabla
        //var datos = tabla.find('tbody tr').map(function () {
        //    var fila = $(this);
        //    var celdas = fila.find('td').map(function () {
        //        return $(this).text();
        //    }).get();
        //    return [celdas]; // Se envuelve el arreglo de celdas dentro de otro arreglo
        //}).get();

        // Obtener los datos de la tabla
        var datos = tabla.find('tbody tr').map(function () {
            var fila = $(this);
            var celdas = fila.find('td').map(function (");
            WriteLiteral(@") {
                return $(this).text();
            }).get();
            return [celdas];
        }).get();

        // Crear el objeto de configuración para autoTable
        var config = {
            head: [encabezados],
            body: datos,
            startY: 65,
            didDrawPage: function (data) {
                // Establecer el margen superior de la tabla en cada página
                data.settings.margin.top = 45;

                ///reyeno
                var img = new Image();
                img.src = '/img/Banner_Rechazadaspng.png';
                data.doc.addImage(img, 'JPEG', data.settings.margin.left, 10, 182, 50);


                // Establecer la posición de inicio de la tabla en cada página
                data.startY = data.settings.margin.top + 50; // Altura de la imagen
            },
            headStyles: {
                fillColor: [40, 180, 99],
                fontSize: 12,
            },
            theme: 'grid',
            didPars");
            WriteLiteral(@"eCell: function (data) {
                // Agregar la imagen en la primera celda de la primera fila
                if (data.section === 'head' && data.row.index === 0 && data.cell.index === 0) {
                    var img = new Image();
                    img.src = '/img/Banner_Rechazadaspng.png';
                    var imgData = getBase64Image(img);
                    data.cell.styles.fillColor = '#FFFFFF';
                    data.cell.styles.textColor = '#000000';
                    data.cell.styles.fontSize = 15;
                    data.cell.styles.cellPadding = 1;
                    data.cell.styles.overflow = 'linebreak';
                    data.cell.contentWidth = 190;
                    data.cell.text = '';
                    data.cell.raw = imgData;
                }
            }
        };

        // Crear el PDF con autoTable
        var pdf = new jsPDF();
        pdf.autoTable(config);

        // Obtener la URL del objeto Blob y establecerla como src del iframe");
            WriteLiteral(@"
        var pdfBlob = pdf.output('blob');
        var pdfUrl = URL.createObjectURL(pdfBlob);
        $('#pdf').attr('src', pdfUrl);
    });

    // Función para convertir la imagen en base64
    function getBase64Image(img) {
        var canvas = document.createElement(""canvas"");
        canvas.width = img.width;
        canvas.height = img.height;
        var ctx = canvas.getContext(""2d"");
        ctx.drawImage(img, 0, 0);
        var dataURL = canvas.toDataURL(""image/jpeg"");
        return dataURL.replace(/^data:image\/(png|jpg);base64,/, """");
    }


</script>

");
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
