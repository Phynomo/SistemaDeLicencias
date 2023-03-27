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
            ViewBag.Resultado = TempData["tili"];

            List<VWTiposLicenciasViewModel> listado = new List<VWTiposLicenciasViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/TipoLicencia/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];


                    listado = JsonConvert.DeserializeObject<List<VWTiposLicenciasViewModel>>(jsonArray.ToString());
        

                }
                return View(listado);
            }
        }
        
        [HttpGet]
        public IActionResult Create()
        {
                return View();
        }
        



        [HttpPost]
        public async Task<IActionResult> Create(TipoLicenciasViewModel tipoLicenciasViewModel)
        {

            tipoLicenciasViewModel.tili_UsuCreacion = 1;
            string json = JsonConvert.SerializeObject(tipoLicenciasViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/TipoLicencia/Insertar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_baseurl + "api/TipoLicencia/Insertar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                TempData["tili"] = "CreateSuccess";
                Console.WriteLine(responseContent);

                return RedirectToAction("Index");
            }
            else
            {
                TempData["tili"] = "CreateError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/TipoLicencia/Buscar?id=" + id);
               
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    
                var lice = JsonConvert.DeserializeObject<VWTiposLicenciasViewModel>(jsonResponse);
                return View(lice);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Edit(TipoLicenciasViewModel tipoLicenciasViewModel)
        {

            tipoLicenciasViewModel.tili_UsuModificacion = 1;
            string json = JsonConvert.SerializeObject(tipoLicenciasViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/TipoLicencia/Editar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/TipoLicencia/Editar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["tili"] = "EditSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["tili"] = "EditError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return View(tipoLicenciasViewModel);
          
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(TipoLicenciasViewModel tipoLicenciasViewModel)
        {

            
            string json = JsonConvert.SerializeObject(tipoLicenciasViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/TipoLicencia/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/TipoLicencia/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["tili"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["tili"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return RedirectToAction("Index");

        }

    }
}
