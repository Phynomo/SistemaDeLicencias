using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaLicencias.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static string _baseurl;

        public HomeController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
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

                    int Hombre = 0;
                    int Mujer = 0;
                    foreach (var item in listado)
                    {
                        if(item.soli_Sexo == "M")
                        {
                            Hombre += 1;
                        }
                        else
                        {
                            Mujer += 1;
                        }
                    }
                    ViewBag.Hombre  = Hombre;
                    ViewBag.Mujer   = Mujer;

                }
                return View(listado);
            }
        }


        public async Task<IActionResult> PantallasMenu(PantallaViewModel item)
        {
            item.role_Id = (int)HttpContext.Session.GetInt32("Rol");
            item.esAdmin = Convert.ToBoolean(HttpContext.Session.GetString("EsAdmin"));

            using (var httpClient = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(item);

                var client = new HttpClient();
                client.BaseAddress = new Uri(_baseurl + "api/Usuario/PantallasMenu");
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PutAsync(_baseurl + "api/Usuario/PantallasMenu", content);
                var jsonResponse = await response.Content.ReadAsStringAsync();

                JObject jsonObj = JObject.Parse(jsonResponse);
                

                var pantalla = JsonConvert.DeserializeObject<List<PantallaViewModel>>(jsonObj["data"].ToString());

                return Json(pantalla);


            }
        }


        [HttpGet]
        public IActionResult Destroysession()
        {


            HttpContext.Session.SetInt32("empe_Id", 0);
            HttpContext.Session.SetString("Nombre", "");
            HttpContext.Session.SetString("Cargo", "");
            HttpContext.Session.SetInt32("Sucursal", 0);
            HttpContext.Session.SetInt32("usur_Id", 0);
            HttpContext.Session.SetString("EsAdmin", "");
            HttpContext.Session.SetInt32("Rol", 0);
            HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Response.Headers.Add("Pragma", "no-cache");
            HttpContext.Response.Headers.Add("Expires", "0");


            return RedirectToAction("Index","Login");
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      
        public IActionResult ERRORFIU()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
