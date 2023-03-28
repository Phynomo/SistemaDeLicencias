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
    public class EmpleadoController : Controller
    {
        private static string _baseurl;

        public EmpleadoController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["empe"];

            List<VWEmpleadosViewModel> listado = new List<VWEmpleadosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];


                    listado = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(jsonArray.ToString());


                }
                return View(listado);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {

                var responseDepartamento = await httpClient.GetAsync(_baseurl + "api/Solicitante/DepartamentoDropDownList");

                var jsonResponse = await responseDepartamento.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(jsonResponse);
                JArray depa_Id = JArray.Parse(jsonObj["data"].ToString());

                ViewBag.depa_Id = new SelectList(depa_Id, "depa_Id", "depa_Nombre");

                var responseCargos = await httpClient.GetAsync(_baseurl + "api/Empleado/Cargos");

                if (responseCargos.IsSuccessStatusCode)
                {
                    var Cargos = await responseCargos.Content.ReadAsStringAsync();
                    var listadoCargos = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Cargos);
                    ViewBag.Cargos = new SelectList(listadoCargos, "carg_Id", "carg_Descripcion");
                }

                var responseSucursales = await httpClient.GetAsync(_baseurl + "api/Empleado/Sucursales");

                if (responseSucursales.IsSuccessStatusCode)
                {
                    var Sucursales = await responseSucursales.Content.ReadAsStringAsync();
                    var listadoSucursales = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Sucursales);
                    ViewBag.Sucursales = new SelectList(listadoSucursales, "sucu_Id", "sucu_Nombre");
                }

                var responseECiviles = await httpClient.GetAsync(_baseurl + "api/Empleado/EstadosCiviles");

                if (responseECiviles.IsSuccessStatusCode)
                {
                    var Estados = await responseECiviles.Content.ReadAsStringAsync();
                    var listadoEstados = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Estados);
                    ViewBag.EstadosCiviles = new SelectList(listadoEstados, "eciv_Id", "eciv_Descripcion");
                }
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmpleadosViewModel empleadosViewModel)
        {

            empleadosViewModel.empe_UsuCreacion = 1;
            string json = JsonConvert.SerializeObject(empleadosViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Empleado/Insertar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_baseurl + "api/Empleado/Insertar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                TempData["empe"] = "CreateSuccess";
                Console.WriteLine(responseContent);

                return RedirectToAction("Index");
            }
            else
            {
                TempData["empe"] = "CreateError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);

                using (var httpClient = new HttpClient())
                {
                    var responseCargos = await httpClient.GetAsync(_baseurl + "api/Empleado/Cargos");

                    if (responseCargos.IsSuccessStatusCode)
                    {
                        var Cargos = await responseCargos.Content.ReadAsStringAsync();
                        var listadoCargos = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Cargos);
                        ViewBag.Cargos = new SelectList(listadoCargos, "carg_Id", "carg_Descripcion", empleadosViewModel.carg_Id);
                    }

                    var responseSucursales = await httpClient.GetAsync(_baseurl + "api/Empleado/Sucursales");

                    if (responseSucursales.IsSuccessStatusCode)
                    {
                        var Sucursales = await responseSucursales.Content.ReadAsStringAsync();
                        var listadoSucursales = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Sucursales);
                        ViewBag.Sucursales = new SelectList(listadoSucursales, "sucu_Id", "sucu_Nombre", empleadosViewModel.sucu_Id);
                    }

                    var responseECiviles = await httpClient.GetAsync(_baseurl + "api/Empleado/EstadosCiviles");

                    if (responseECiviles.IsSuccessStatusCode)
                    {
                        var Estados = await responseECiviles.Content.ReadAsStringAsync();
                        var listadoEstados = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Estados);
                        ViewBag.EstadosCiviles = new SelectList(listadoEstados, "eciv_Id", "eciv_Descripcion", empleadosViewModel.eciv_Id );
                    }
                }

            }

            return View(empleadosViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<EmpleadosViewModel>(jsonResponse);

                var responseCargos = await httpClient.GetAsync(_baseurl + "api/Empleado/Cargos");

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




                if (responseCargos.IsSuccessStatusCode)
                {
                    var Cargos = await responseCargos.Content.ReadAsStringAsync();
                    var listadoCargos = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Cargos);
                    ViewBag.Cargos = new SelectList(listadoCargos, "carg_Id", "carg_Descripcion", lice.carg_Id);
                }

                var responseSucursales = await httpClient.GetAsync(_baseurl + "api/Empleado/Sucursales");

                if (responseSucursales.IsSuccessStatusCode)
                {
                    var Sucursales = await responseSucursales.Content.ReadAsStringAsync();
                    var listadoSucursales = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Sucursales);
                    ViewBag.Sucursales = new SelectList(listadoSucursales, "sucu_Id", "sucu_Nombre", lice.sucu_Id);
                }

                var responseECiviles = await httpClient.GetAsync(_baseurl + "api/Empleado/EstadosCiviles");

                if (responseECiviles.IsSuccessStatusCode)
                {
                    var Estados = await responseECiviles.Content.ReadAsStringAsync();
                    var listadoEstados = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Estados);
                    ViewBag.EstadosCiviles = new SelectList(listadoEstados, "eciv_Id", "eciv_Descripcion", lice.eciv_Id);
                }


                return View(lice);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmpleadosViewModel empleadosViewModel)
        {

            empleadosViewModel.empe_UsuModificacion = 1;
            string json = JsonConvert.SerializeObject(empleadosViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Empleado/Editar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Empleado/Editar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["empe"] = "EditSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["tili"] = "EditError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return View(empleadosViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmpleadosViewModel empleadosViewModel)
        {


            string json = JsonConvert.SerializeObject(empleadosViewModel);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Empleado/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Empleado/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["tili"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["soli"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWEmpleadosViewModel>(jsonResponse);
                return View(lice);
            }

        }

    }
}
