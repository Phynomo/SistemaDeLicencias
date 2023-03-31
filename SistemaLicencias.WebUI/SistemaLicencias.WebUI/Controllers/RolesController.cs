using Microsoft.AspNetCore.Http;
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
            #region Tiene permiso?
            var client = new HttpClient();
            int esAdmin = 0;
            if (HttpContext.Session.GetString("EsAdmin") == "True")
            {
                esAdmin = 1;
            }

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");//donde dice pant id tenes que metelo en duro y tiene que se el mismo id que en la base de datos sql

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");

            if (Acceso.IsSuccessStatusCode)
            {
                var responseContent = await Acceso.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                if (message == "0")
                {
                    return RedirectToAction("Index","Home");
                }
            }
            #endregion


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
            #region Tiene permiso?
            var client = new HttpClient();
            int esAdmin = 0;
            if (HttpContext.Session.GetString("EsAdmin") == "True")
            {
                esAdmin = 1;
            }

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");//donde dice pant id tenes que metelo en duro y tiene que se el mismo id que en la base de datos sql

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");

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

                var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                if (responsePantallas.IsSuccessStatusCode)
                {
                    var Listado = await responsePantallas.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(Listado);
                    JArray listadoPantallas = JArray.Parse(jsonObj["data"].ToString());

                    //var listadoPantallas = JsonConvert.DeserializeObject<List<VWPantallasViewModelcs>>(Listado);
                    //ViewBag.Pantallas = listadoPantallas;
                    ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre");
                }

                return View();
                }
            }

        [HttpPost]
        public async Task<IActionResult> Create(RolesViewModel roles)
        {

            roles.role_UsuCreacion = 1;
            string json = JsonConvert.SerializeObject(roles);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Roles/Insertar");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseurl + "api/Roles/Insertar", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                int code = (int)jsonObj["code"];
                if (code == 200)
                {
                    PantallasPorRolesViewModel pant = new PantallasPorRolesViewModel();
                    pant.role_Id = Convert.ToInt32(message);
                    var client2 = new HttpClient();
                    var clientD = new HttpClient();

                    string jsonD = JsonConvert.SerializeObject(pant);
                    clientD.BaseAddress = new Uri(_baseurl + "api/Roles/EliminarPantallasXRol");
                    var contentD = new StringContent(jsonD, System.Text.Encoding.UTF8, "application/json");
                    var responseD = await client.PostAsync(_baseurl + "api/Roles/EliminarPantallasXRol", contentD);

                    if (roles.pantallas != null)
                    {
                         foreach (var item in roles.pantallas)
                        {
                            pant.pant_Id = Convert.ToInt32(item);
                            pant.prol_UsuCreacion = roles.role_UsuCreacion;
                            string json2 = JsonConvert.SerializeObject(pant);

                            client2.BaseAddress = new Uri(_baseurl + "api/Roles/InsertarPantallasXRol");
                        var content2 = new StringContent(json2, System.Text.Encoding.UTF8, "application/json");
                        var response2 = await client.PostAsync(_baseurl + "api/Roles/InsertarPantallasXRol", content2);

                        }
                    }
                   

                }
                else if (message == "Registro repetido")
                {
                    ViewBag.Resultado = "RolRepetido";
                    using (var httpClient = new HttpClient())
                    {
                        var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                        if (responsePantallas.IsSuccessStatusCode)
                        {
                            var Listado = await responsePantallas.Content.ReadAsStringAsync();
                            JObject jsonObj2 = JObject.Parse(Listado);
                            JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                            ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                        }

                    }

                    return View(roles);
                }
                else
                {
                    ViewBag.Resultado = "ErrorInesperado";
                    using (var httpClient = new HttpClient())
                    {
                        var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                        if (responsePantallas.IsSuccessStatusCode)
                        {
                            var Listado = await responsePantallas.Content.ReadAsStringAsync();
                            JObject jsonObj2 = JObject.Parse(Listado);
                            JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                            ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                        }

                    }
                    return View(roles);
                }

                TempData["role"] = "CreateSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Resultado = "ErrorInesperado";
                using (var httpClient = new HttpClient())
                {
                    var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                    if (responsePantallas.IsSuccessStatusCode)
                    {
                        var Listado = await responsePantallas.Content.ReadAsStringAsync();
                        JObject jsonObj2 = JObject.Parse(Listado);
                        JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                        ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                    }

                }
                return View(roles);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            #region Tiene permiso?
            var client = new HttpClient();
            int esAdmin = 0;
            if (HttpContext.Session.GetString("EsAdmin") == "True")
            {
                esAdmin = 1;
            }

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");//donde dice pant id tenes que metelo en duro y tiene que se el mismo id que en la base de datos sql

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");

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
                var response = await httpClient.GetAsync(_baseurl + "api/Roles/Buscar?id=" + id);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var lice = JsonConvert.DeserializeObject<RolesViewModel>(jsonResponse);
                
                var response2 = await httpClient.GetAsync(_baseurl + "api/Roles/ListadoPXRPorR?role_Id=" + id);
                var jsonResponse2 = await response2.Content.ReadAsStringAsync();
                var Pantallas = JsonConvert.DeserializeObject<List<PantallasViewModel>>(jsonResponse2 );
                
                string[] pant_IDs = new string[Pantallas.Count()];
                int i = 0;
               
                foreach (var item in Pantallas)
                {
                    pant_IDs[i] = item.pant_Id.ToString();
                    i++;
                }

                var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                if (responsePantallas.IsSuccessStatusCode)
                {
                    var Listado = await responsePantallas.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(Listado);
                    JArray listadoPantallas = JArray.Parse(jsonObj["data"].ToString());
                    ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", pant_IDs);
                }
                lice.pantallas = pant_IDs;
                return View(lice);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RolesViewModel roles)
        {

            roles.role_UsuModificacion= 1;
            string json = JsonConvert.SerializeObject(roles);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Roles/Editar");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_baseurl + "api/Roles/Editar", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                int code = (int)jsonObj["code"];
                if (code == 200)
                {
                    PantallasPorRolesViewModel pant = new PantallasPorRolesViewModel();
                    pant.role_Id = roles.role_Id;
                    var client2 = new HttpClient();
                    var clientD = new HttpClient();

                    string jsonD = JsonConvert.SerializeObject(pant);
                    clientD.BaseAddress = new Uri(_baseurl + "api/Roles/EliminarPantallasXRol");
                    var contentD = new StringContent(jsonD, System.Text.Encoding.UTF8, "application/json");
                    var responseD = await client.PutAsync(_baseurl + "api/Roles/EliminarPantallasXRol", contentD);

                    if (roles.pantallas != null)
                    {
                        foreach (var item in roles.pantallas)
                        {
                            pant.pant_Id = Convert.ToInt32(item);
                            pant.prol_UsuCreacion = Convert.ToInt32(roles.role_UsuModificacion);
                            string json2 = JsonConvert.SerializeObject(pant);

                            client2.BaseAddress = new Uri(_baseurl + "api/Roles/InsertarPantallasXRol");
                            var content2 = new StringContent(json2, System.Text.Encoding.UTF8, "application/json");
                            var response2 = await client.PostAsync(_baseurl + "api/Roles/InsertarPantallasXRol", content2);

                        }
                    }
                   

                }
                else if (message == "Registro repetido")
                {
                    ViewBag.Resultado = "RolRepetido";
                    using (var httpClient = new HttpClient())
                    {
                        var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                        if (responsePantallas.IsSuccessStatusCode)
                        {
                            var Listado = await responsePantallas.Content.ReadAsStringAsync();
                            JObject jsonObj2 = JObject.Parse(Listado);
                            JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                            ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                        }

                    }

                    return View(roles);
                }
                else
                {
                    ViewBag.Resultado = "ErrorInesperado";
                    using (var httpClient = new HttpClient())
                    {
                        var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                        if (responsePantallas.IsSuccessStatusCode)
                        {
                            var Listado = await responsePantallas.Content.ReadAsStringAsync();
                            JObject jsonObj2 = JObject.Parse(Listado);
                            JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                            ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                        }

                    }
                    return View(roles);
                }

                TempData["role"] = "EditSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Resultado = "ErrorInesperado";
                using (var httpClient = new HttpClient())
                {
                    var responsePantallas = await httpClient.GetAsync(_baseurl + "api/Pantallas/Listado");
                    if (responsePantallas.IsSuccessStatusCode)
                    {
                        var Listado = await responsePantallas.Content.ReadAsStringAsync();
                        JObject jsonObj2 = JObject.Parse(Listado);
                        JArray listadoPantallas = JArray.Parse(jsonObj2["data"].ToString());
                        ViewBag.Pantallas = new SelectList(listadoPantallas, "pant_Id", "pant_Nombre", roles.pantallas);
                    }

                }
                return View(roles);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(RolesViewModel roles)
        {
            string json = JsonConvert.SerializeObject(roles);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Roles/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Roles/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                if (message == "Rol en uso")
                {
                    TempData["role"] = "UsoRol";
                    return RedirectToAction("Index");
                }
                Console.WriteLine(responseContent);
                TempData["role"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["role"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }

            return RedirectToAction("Index");

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

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");//donde dice pant id tenes que metelo en duro y tiene que se el mismo id que en la base de datos sql

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=7");

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
                var response = await httpClient.GetAsync(_baseurl + "api/Roles/Buscar?id=" + id);
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var lice = JsonConvert.DeserializeObject<VWRolesViewModel>(jsonResponse);

                var response2 = await httpClient.GetAsync(_baseurl + "api/Roles/ListadoPXRPorR?role_Id=" + id);
                var jsonResponse2 = await response2.Content.ReadAsStringAsync();
                var Pantallas = JsonConvert.DeserializeObject<List<PantallasViewModel>>(jsonResponse2);

                ViewBag.Pantallas = Pantallas;
                return View(lice);
            }
        }


    }
}
