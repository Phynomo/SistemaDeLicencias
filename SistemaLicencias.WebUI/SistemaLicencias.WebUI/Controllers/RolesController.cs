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
    public class RolesController : Controller
    {

        private static string _baseurl;

        public RolesController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["role"];

            List<VWRolesViewModel> listado = new List<VWRolesViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Roles/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.Mensaje = message;
                    listado = JsonConvert.DeserializeObject<List<VWRolesViewModel>>(jsonArray.ToString());
                }


                return View(listado);
            }

        }
            [HttpGet]
            public async Task<IActionResult> Create()
            {
            using (var httpClient = new HttpClient())
            {

                var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                if (responsePantallas.IsSuccessStatusCode)
                {
                    var Listado = await responsePantallas.Content.ReadAsStringAsync();
                    var listadoPantallas = JsonConvert.DeserializeObject<List<VWPantallasViewModelcs>>(Listado);
                    ViewBag.Pantallas = listadoPantallas;
                }

                return View();
            }
        }
        
            [HttpPost]
            public IActionResult Create(RolesViewModel item)
            {


                return View();
            }

    }
}
