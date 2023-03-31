using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            #region Tiene permiso?
            var client = new HttpClient();
            int esAdmin = 0;
            if (HttpContext.Session.GetString("EsAdmin") == "True")
            {
                esAdmin = 1;
            }

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=1");

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=1");

            if (Acceso.IsSuccessStatusCode)
            {
                var responseContent = await Acceso.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                if (message == "0")
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            #endregion



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


            #region Tiene permiso?
            var client = new HttpClient();
            int esAdmin = 0;
            if (HttpContext.Session.GetString("EsAdmin") == "True")
            {
                esAdmin = 1;
            }

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=1");

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=1");

            if (Acceso.IsSuccessStatusCode)
            {
                var responseContent = await Acceso.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                if (message == "0")
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            #endregion







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

        [HttpPost]
        public async Task<IActionResult> Delete(AprobadosViewModel AprobadosViewModel)
        {


            string json = JsonConvert.SerializeObject(AprobadosViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Aprobados/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Aprobados/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["apro"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["apro"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return RedirectToAction("Index");

        }

    }
}
