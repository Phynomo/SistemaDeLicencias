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
    public class UsuarioController : Controller
    {

        private static string _baseurl;

        public UsuarioController()
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

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=9");

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=9");

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

            ViewBag.Resultado = TempData["user"];

            List<VWUsuarioViewModel> listado = new List<VWUsuarioViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Usuario/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.Mensaje = message;
                    listado = JsonConvert.DeserializeObject<List<VWUsuarioViewModel>>(jsonArray.ToString());
                }


                var Rol = await httpClient.GetAsync(_baseurl + "api/Usuario/RolDropDownList");
                var jsonResponseRol = await Rol.Content.ReadAsStringAsync();
                JObject jsonObjRol = JObject.Parse(jsonResponseRol);
                JArray rl = JArray.Parse(jsonObjRol["data"].ToString());
                ViewBag.role_Id = new SelectList(rl, "role_Id", "role_Nombre");


                var Empleado = await httpClient.GetAsync(_baseurl + "api/Empleado/Listado");
                var jsonResponsEmpleado = await Empleado.Content.ReadAsStringAsync();
                JObject jsonObjEmpleado = JObject.Parse(jsonResponsEmpleado);
                JArray empe = JArray.Parse(jsonObjEmpleado["data"].ToString());
                ViewBag.empe_Id = new SelectList(empe, "empe_Id", "empe_NombreCompleto");

                return View(listado);
            }

        }


     
        [HttpPost]
        public async Task<IActionResult> Create(UsuariosViewModel usuario)
        {

            usuario.user_UsuCreacion = Convert.ToInt32(HttpContext.Session.GetInt32("usur_Id"));
            string json = JsonConvert.SerializeObject(usuario);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Usuario/Insertar");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseurl + "api/Usuario/Insertar", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                TempData["user"] = "CreateSuccess";
                Console.WriteLine(responseContent);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["user"] = "CreateError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }


       
        [HttpPost]
        public async Task<IActionResult> Edit(UsuariosViewModel usuarios)
        {

            usuarios.user_UsuModificacion = Convert.ToInt32(HttpContext.Session.GetInt32("usur_Id"));
            string json = JsonConvert.SerializeObject(usuarios);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Usuario/Editar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Usuario/Editar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["user"] = "EditSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["user"] = "editError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(UsuariosViewModel usuarios)
        {
            string json = JsonConvert.SerializeObject(usuarios);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Usuario/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Usuario/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["user"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["user"] = "DeleteError";
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

            client.BaseAddress = new Uri(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=9");

            var Acceso = await client.GetAsync(_baseurl + $"api/Usuario/AccesoAPantalla?esAdmin={esAdmin}&role_Id={HttpContext.Session.GetInt32("Rol")}&pant_Id=9");

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
                var response = await httpClient.GetAsync(_baseurl + "api/Usuario/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWUsuarioViewModel>(jsonResponse);
                return View(lice);
            }
        }
    }
}
