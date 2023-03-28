using Microsoft.AspNetCore.Mvc;
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
    public class AprobadosController : Controller
    {
        private static string _baseurl;

        public AprobadosController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["apro"];

            List<VWAprobadosViewModel> listado = new List<VWAprobadosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Aprobados/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];


                    listado = JsonConvert.DeserializeObject<List<VWAprobadosViewModel>>(jsonArray.ToString());


                }
                return View(listado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Aprobados/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWAprobadosViewModel>(jsonResponse);

                var responseListado = await httpClient.GetAsync(_baseurl + "api/Rechazados/ListadoxSolicitud?stud_Id=" + id);

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
