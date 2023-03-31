using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaLicencias.API.models;
using SistemaLicencias.BusinessLogic.Service;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public SolicitudController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }


        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoSolicitud();
            return Ok(list);
        }


        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {

            var list = _licenciaServivce.BuscarSoliciud(id);
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert(SolicitudViewModel solicitud)
        {

            var item = _mapper.Map<tbSolicitud>(solicitud);
            var response = _licenciaServivce.InsertarSolicitud(item);
            return Ok(response);
        }

        [HttpPost("Editar")]
        public IActionResult Update(SolicitudViewModel solicitud)
        {

            var item = _mapper.Map<tbSolicitud>(solicitud);
            var response = _licenciaServivce.EditarSolicitud(item);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(SolicitudViewModel solicitud)
        {
            var item = _mapper.Map<tbSolicitud>(solicitud);
            var result = _licenciaServivce.EliminarSolicitud(item);
            return Ok(result);
        }

        [HttpPost("RechazarSolicitud")]
        public IActionResult Reject(RechazadosViewModel rechazados)
        {

            var item = _mapper.Map<tbRechazados>(rechazados);
            var response = _licenciaServivce.Rezachar(item);
            return Ok(response);
        }

        [HttpPost("AceptarSolicitud")]
        public IActionResult Accept(AprobadosViewModel aprobados)
        {
            var item = _mapper.Map<tbAprobados>(aprobados);
            var response = _licenciaServivce.Aceptar(item);
            return Ok(response);
        }





        [HttpGet("TipoLicenciaDropDownList")]
        public IActionResult TipoLicenciaDropDownList()
        {
            var list = _licenciaServivce.TipoLocenciDropDownList();
            return Ok(list);
        }

        [HttpGet("SolicitanteDropDownList")]
        public IActionResult SolicitanteDropDownList()
        {
            var list = _licenciaServivce.SolicitanteDropDownList();
            return Ok(list);
        }

        [HttpGet("SucursalDropDownList")]
        public IActionResult SucursalDropDownList()
        {
            var list = _licenciaServivce.ListadoSucursales();
            return Ok(list);
        }

    }
}
