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
    public class ReportesController : Controller
    {
        private static string _baseurl;

        public ReportesController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ReportesAprobados")]
        public async Task<IActionResult> ReportesAprobados()
        {
            ViewBag.Resultado = TempData["apro"];

            List<ReporteAprobadosViewModel> listado = new List<ReporteAprobadosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Aprobados/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];


                    listado = JsonConvert.DeserializeObject<List<ReporteAprobadosViewModel>>(jsonArray.ToString());


                }
                return View(listado);
            }
        }


        [HttpGet("ReportesRechazos")]
        public async Task<IActionResult> ReportesRechazos()
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


    }
}
