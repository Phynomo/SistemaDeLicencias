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
    public class TipoLicenciasController : Controller
    {

        private static string _baseurl;

        public TipoLicenciasController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {

            List<VWTiposLicenciasViewModel> listado = new List<VWTiposLicenciasViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/TipoLicencia/Listado");

                // Analizar la respuesta en una lista de objetos de modelo
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    jsonResponse = jsonResponse.Replace("[", "");
                    jsonResponse = jsonResponse.Replace("]", "");

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JObject dataObj = (JObject)jsonObj["data"];
                    string message = (string)jsonObj["message"];

                    ViewBag.Mensaje = message;

                    listado = JsonConvert.DeserializeObject<List<VWTiposLicenciasViewModel>>("[" + dataObj.ToString() + "]");
                }
                return View(listado);
            }
            //List<ClientesModel> listado = await _serviceApi.List();
            //return View(listado);
        }
    }
}
