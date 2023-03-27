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
    public class SolicitanteController : ControllerBase
    {
        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public SolicitanteController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }


        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoSolicitantes();
            return Ok(list);
        }


        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {

            var list = _licenciaServivce.BuscarSolicitante(id);
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert(SolicitanteViewModel solicitante)
        {

            var item = _mapper.Map<tbSolicitantes>(solicitante);
            var response = _licenciaServivce.InsertarSolicitante(item);
            return Ok(response);
        }

        [HttpPost("Editar")]
        public IActionResult Update(SolicitanteViewModel solicitante)
        {

            var item = _mapper.Map<tbSolicitantes>(solicitante);
            var response = _licenciaServivce.EditarSolicitantes(item);
            return Ok(response);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(SolicitanteViewModel solicitante)
        {
            var item = _mapper.Map<tbSolicitantes>(solicitante);
            var result = _licenciaServivce.EliminarSolicitantes(item);
            return Ok(result);
        }


        [HttpGet("DepartamentoDropDownList")]
        public IActionResult DeparatemetosDropDownList()
        {
            var list = _licenciaServivce.DepartamentosDropDownList();
            return Ok(list);
        }

        [HttpGet("MunicipioDropDownList")]
        public IActionResult MunicipioDropDownList(string id)
        {
            var list = _licenciaServivce.MunicipiosDropDownList(Convert.ToInt32(id));
            return Ok(list);
        }
    }
}
