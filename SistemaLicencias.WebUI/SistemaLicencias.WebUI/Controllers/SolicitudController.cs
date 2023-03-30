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
    public class SolicitudController : Controller
    {

        private static string _baseurl;

        public SolicitudController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Resultado = TempData["stud"];

            List<VWSolicitudViewModel> listado = new List<VWSolicitudViewModel>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitud/Listado");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.Mensaje = message;
                    listado = JsonConvert.DeserializeObject<List<VWSolicitudViewModel>>(jsonArray.ToString());
                }


                var TipoLicencias = await httpClient.GetAsync(_baseurl + "api/TipoLicencia/Listado");
                var jsonResponseTipoLicencia = await TipoLicencias.Content.ReadAsStringAsync();
                JObject jsonObjTipoLocencia = JObject.Parse(jsonResponseTipoLicencia);
                JArray licencia = JArray.Parse(jsonObjTipoLocencia["data"].ToString());
                ViewBag.tili_Id = new SelectList(licencia, "tili_Id", "tili_Descripcion");

                var Solicitante = await httpClient.GetAsync(_baseurl + "api/Solicitante/Listado");
                var jsonResponseSolicitante = await Solicitante.Content.ReadAsStringAsync();
                JObject jsonObjSolicitante = JObject.Parse(jsonResponseSolicitante);
                JArray soli = JArray.Parse(jsonObjSolicitante["data"].ToString());
                ViewBag.soli_Id = new SelectList(soli, "soli_Id", "soli_NombreCompleto");



                var responseSucursales = await httpClient.GetAsync(_baseurl + "api/Empleado/Sucursales");
                if (responseSucursales.IsSuccessStatusCode)
                {
                    var Sucursales = await responseSucursales.Content.ReadAsStringAsync();
                    var listadoSucursales = JsonConvert.DeserializeObject<List<VWEmpleadosViewModel>>(Sucursales);
                    ViewBag.sucu_Id = new SelectList(listadoSucursales, "sucu_Id", "sucu_Nombre");
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
        public async Task<IActionResult> Create(SolicitudViewModel solicitud)
        {

            solicitud.stud_UsuCreacion = 1;
            string json = JsonConvert.SerializeObject(solicitud);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitud/Insertar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(_baseurl + "api/Solicitud/Insertar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                TempData["stud"] = "CreateSuccess";
                Console.WriteLine(responseContent);

                return RedirectToAction("Index");
            }
            else
            {
                TempData["stud"] = "CreateError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }


            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Edit(SolicitudViewModel solicitud)
        {
            solicitud.stud_UsuModificacion = 1;
            string json = JsonConvert.SerializeObject(solicitud);
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitud/Editar");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseurl + "api/Solicitud/Editar", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                TempData["stud"] = "EditSuccess";
                Console.WriteLine(responseContent);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["stud"] = "EditError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(SolicitudViewModel solicitud)
        {
            string json = JsonConvert.SerializeObject(solicitud);

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitud/Eliminar");

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync(_baseurl + "api/Solicitud/Eliminar", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);
                TempData["stud"] = "DeleteSuccess";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["stud"] = "DeleteError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Solicitud/Buscar?id=" + id);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                var lice = JsonConvert.DeserializeObject<VWSolicitudViewModel>(jsonResponse);
                return View(lice);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Reject(RechazadosViewModel rechazados)
        {
            rechazados.empe_Id = 1;
            rechazados.rech_UsuCreacion = 1;
            
            string json = JsonConvert.SerializeObject(rechazados);
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitud/RechazarSolicitud");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseurl + "api/Solicitud/RechazarSolicitud", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                TempData["stud"] = "RejectSuccess";
                Console.WriteLine(responseContent);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["stud"] = "RejectError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Accept(AprovadosViewModel aprovados)
        {
            aprovados.empe_Id = 1;
            aprovados.apro_UsuCreacion = 1;

            string json = JsonConvert.SerializeObject(aprovados);
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl + "api/Solicitud/AceptarSolicitud");
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseurl + "api/Solicitud/AceptarSolicitud", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                JObject jsonObj = JObject.Parse(responseContent);
                string message = (string)jsonObj["message"];
                if (message == "La solicitud debe ser pagada")
                {
                    TempData["stud"] = "DebePagar";
                    return RedirectToAction("Index");
                }

                TempData["stud"] = "AcceptSuccess";
                Console.WriteLine(responseContent);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["stud"] = "AcceptError";
                Console.WriteLine("La solicitud falló con el código de estado: " + response.StatusCode);
            }
            return RedirectToAction("Index");
        }

        //[HttpGet("ReportesAprobados")]
        //public async Task<IActionResult> ReportesAprobados()
        //{
        //    ViewBag.Resultado = TempData["apro"];

        //    List<ReporteAprobadosViewModel> listado = new List<ReporteAprobadosViewModel>();

        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.GetAsync(_baseurl + "api/Aprobados/Listado");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonResponse = await response.Content.ReadAsStringAsync();

        //            JObject jsonObj = JObject.Parse(jsonResponse);
        //            JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
        //            string message = (string)jsonObj["message"];


        //            listado = JsonConvert.DeserializeObject<List<ReporteAprobadosViewModel>>(jsonArray.ToString());


        //        }
        //        return View(listado);
        //    }
        //}

    }
}
