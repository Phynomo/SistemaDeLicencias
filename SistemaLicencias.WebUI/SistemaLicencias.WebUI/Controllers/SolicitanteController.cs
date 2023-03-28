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
    public class SolicitanteController : Controller
    {

        private static string _baseurl;

        public SolicitanteController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["soli"];

            List<VWSolicitantesViewModel> listado = new List<VWSolicitantesViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitante/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.Mensaje = message;                
                    listado = JsonConvert.DeserializeObject<List<VWSolicitantesViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        //CREATE
        [HttpGet]
        public  async Task<IActionResult> Create()
        {

            //CARGAR VIEW BAG "DEPARTAMENTOS"
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitante/DepartamentoDropDownList");

                var jsonResponse = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(jsonResponse);
                JArray depa_Id = JArray.Parse(jsonObj["data"].ToString());

                ViewBag.depa_Id = new SelectList(depa_Id, "depa_Id", "depa_Nombre");
            }

            return View();
        }
        public async Task<IActionResult> Create(SolicitantesViewModel solicitantes)
        {
            //CARGAR VIEW BAG "DEPARTAMENTOS"
            using (var httpClient = new HttpClient())
            {
                var Departameto = await httpClient.GetAsync(_baseurl + "api/Solicitante/DepartamentoDropDownList");

                if(Departameto.IsSuccessStatusCode)
                {
                    var LoadDepartamento = await Departameto.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(LoadDepartamento);
                    JArray depa_Id = JArray.Parse(jsonObj["data"].ToString());
                    ViewBag.depa_Id = new SelectList(depa_Id, "depa_Id", "depa_Nombre");



                    var LoadMunicipios  = await httpClient.GetAsync(_baseurl + "api/Solicitante/MunicipioDropDownList?id=" + solicitantes.depa_Id);

                    var LoadMunicipio = await LoadMunicipios.Content.ReadAsStringAsync();
                    JObject jsonObjMuni = JObject.Parse(LoadMunicipio);
                    JArray muni_Id = JArray.Parse(jsonObjMuni["data"].ToString());
                    ViewBag.muni_Id = new SelectList(muni_Id, "muni_Id", "muni_Nombre");
                }

                
            }


            if (Convert.ToString(solicitantes.depa_Id) == "0" || Convert.ToString(solicitantes.depa_Id) == "")
            {
                ModelState.AddModelError("ValidacionDepartamento", "El campo 'Departamento' es requerido");
            }

            if (Convert.ToString(solicitantes.muni_Id) == "0" || Convert.ToString(solicitantes.muni_Id) == "")
            {
                ModelState.AddModelError("ValidacionMunicipio", "El campo 'Municipio' es requerido");
            }

            if (ModelState.IsValid)
            {



                string json = JsonConvert.SerializeObject(solicitantes);

                var client = new HttpClient();
                client.BaseAddress = new Uri(_baseurl + "api/Solicitante/Insertar");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_baseurl + "api/Solicitante/Insertar", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    TempData["soli"] = "CreateSuccess";
                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
                }
            }

            
            return View(solicitantes);
        }

        //EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitante/Buscar?id=" + id);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var lice = JsonConvert.DeserializeObject<SolicitantesViewModel>(jsonResponse);


                
                //CARGAR VIEW BAG "DEPARTAMENTOS" 
                var responseDepto = await httpClient.GetAsync(_baseurl + "api/Solicitante/DepartamentoDropDownList");

                var jsonResponseDepto = await responseDepto.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(jsonResponseDepto);
                JArray depa_Id = JArray.Parse(jsonObj["data"].ToString());
                ViewBag.depa_Id = new SelectList(depa_Id, "depa_Id", "depa_Nombre", lice.depa_Id);


                //ViewBag.muni = lice.muni_Id;

                var LoadMunicipios = await httpClient.GetAsync(_baseurl + "api/Solicitante/MunicipioDropDownList?id=" + lice.depa_Id);

                var LoadMunicipio = await LoadMunicipios.Content.ReadAsStringAsync();
                JObject jsonObjMuni = JObject.Parse(LoadMunicipio);
                JArray muni_Id = JArray.Parse(jsonObjMuni["data"].ToString());
                ViewBag.muni_Id = new SelectList(muni_Id, "muni_Id", "muni_Nombre", lice.muni_Id);


                return View(lice);
            }
        }
        public async Task<IActionResult> Edit(SolicitantesViewModel solicitantesViewModel)
        {

            //CARGAR VIEW BAG "DEPARTAMENTOS"
            using (var httpClient = new HttpClient())
            {
                var Departameto = await httpClient.GetAsync(_baseurl + "api/Solicitante/DepartamentoDropDownList");

                if (Departameto.IsSuccessStatusCode)
                {
                    var LoadDepartamento = await Departameto.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(LoadDepartamento);
                    JArray depa_Id = JArray.Parse(jsonObj["data"].ToString());
                    ViewBag.depa_Id = new SelectList(depa_Id, "depa_Id", "depa_Nombre", solicitantesViewModel.depa_Id);



                    var LoadMunicipios = await httpClient.GetAsync(_baseurl + "api/Solicitante/MunicipioDropDownList?id=" + solicitantesViewModel.depa_Id);

                    var LoadMunicipio = await LoadMunicipios.Content.ReadAsStringAsync();
                    JObject jsonObjMuni = JObject.Parse(LoadMunicipio);
                    JArray muni_Id = JArray.Parse(jsonObjMuni["data"].ToString());
                    ViewBag.muni_Id = new SelectList(muni_Id, "muni_Id", "muni_Nombre");
                }



            }

            if (Convert.ToString(solicitantesViewModel.depa_Id) == "0" || Convert.ToString(solicitantesViewModel.depa_Id) == "")
            {
                ModelState.AddModelError("ValidacionDepartamento", "El campo 'Departamento' es requerido");
            }

            if (Convert.ToString(solicitantesViewModel.muni_Id) == "0" || Convert.ToString(solicitantesViewModel.muni_Id) == "")
            {
                ModelState.AddModelError("ValidacionMunicipio", "El campo 'Municipio' es requerido");
            }

            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(solicitantesViewModel);

                var client = new HttpClient();
                client.BaseAddress = new Uri(_baseurl + "api/Solicitante/Editar");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PostAsync(_baseurl + "api/Solicitante/Editar", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);

                    TempData["soli"] = "EditSuccess";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["soli"] = "EditError";
                    Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
                }
            }
            return View(solicitantesViewModel);
        }


        //DELETE
        [HttpPost]
        public async Task<IActionResult> Delete(SolicitantesViewModel solicitantesViewModel)
        {
            string json = JsonConvert.SerializeObject(solicitantesViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitante/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_baseurl + "api/Solicitante/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);

                TempData["soli"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["tili"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitante/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWSolicitantesViewModel>(jsonResponse);
                return View(lice);
            }

        }









        //DROP DOWN LIST "MUNICIPIOS"
        [HttpGet]
        public async Task<IActionResult> MunicipiosDropDownList(string id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitante/MunicipioDropDownList?id=" + id);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(jsonResponse);
                JArray muni_Id = JArray.Parse(jsonObj["data"].ToString());

               var list = new SelectList(muni_Id, "muni_Id", "muni_Nombre");

                return Json(list);
            }
        }

    }
}
