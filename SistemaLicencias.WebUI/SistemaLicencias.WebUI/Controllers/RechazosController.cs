using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaLicencias.WebUI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Controllers
{
    public class RechazosController : Controller
    {
        private static string _baseurl;

        public RechazosController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["rech"];

            List<VWRechazadosViewModel> listado = new List<VWRechazadosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Rechazados/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    listado = JsonConvert.DeserializeObject<List<VWRechazadosViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Rechazados/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWRechazadosViewModel>(jsonResponse);

                var responseListado = await httpClient.GetAsync(_baseurl + "api/Rechazados/ListadoxSolicitud?stud_Id="+id);

                if (responseListado.IsSuccessStatusCode)
                {
                    var Listado = await responseListado.Content.ReadAsStringAsync();
                    var listadoRechazos = JsonConvert.DeserializeObject<List<VWRechazadosViewModel>>(Listado);
                    ViewBag.ListadoRechazos = listadoRechazos;
                }

                return View(lice);
            }

        }

    }
}
