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
    public class LoginController : Controller
    {
        private static string _baseurl;

        public LoginController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }
        [HttpGet("Login")]
        public IActionResult Index()
        {

            ViewBag.Resultado = TempData["log"];
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Index(UsuariosViewModel usuariosViewModel)
        {
            using (var httpClient = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(usuariosViewModel);

                var client = new HttpClient();
                client.BaseAddress = new Uri(_baseurl + "api/Usuario/IniciarSesion");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(_baseurl + "api/Usuario/IniciarSesion", content);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWUsuariosViewModel>(jsonResponse);
                if (lice == null)
                {
                    ViewBag.Resultado = "InicioFallido";
                    return View();
                }

                HttpContext.Session.SetInt32("empe_Id",     Convert.ToInt32(lice.empe_Id));
                HttpContext.Session.SetString("Nombre",     lice.empe_NombreCompleto);
                HttpContext.Session.SetString("Cargo",      lice.carg_Descripcion);
                HttpContext.Session.SetInt32("Sucursal",    lice.sucu_Id);
                HttpContext.Session.SetInt32("usur_Id",     lice.user_Id);
                HttpContext.Session.SetString("EsAdmin",    lice.user_EsAdmin.ToString());
                HttpContext.Session.SetInt32("Rol",         Convert.ToInt32(lice.role_Id));

                return RedirectToAction("Index","Home");
            }
        }

        [HttpPost("Recuperar")]
        public async Task<IActionResult> Recuperar(UsuariosViewModel usuariosViewModel)
        {
            using (var httpClient = new HttpClient())
            {

                string json = JsonConvert.SerializeObject(usuariosViewModel);

                var client = new HttpClient();
                client.BaseAddress = new Uri(_baseurl + "api/Usuario/Recuperar");

                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await client.PutAsync(_baseurl + "api/Usuario/Recuperar", content);

                var jsonResponse = await response.Content.ReadAsStringAsync();


                JObject jsonObj = JObject.Parse(jsonResponse);
                int code = (int)jsonObj["code"];

                if (code != 200)
                {
                    TempData["log"] = "RecuperacionFallida";
                }
                else
                {
                    TempData["log"] = "RecuperacionExitosa";
                }
                return RedirectToAction("Index");
            }
        }

    }
}
