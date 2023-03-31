using AutoMapper;
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
    public class AprobadosController : Controller
    {
        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public AprobadosController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }



        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoAprovados();
            return Ok(list);
        }

        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {
            var list = _licenciaServivce.BuscarAprovados(id);
            return Ok(list);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(AprobadosViewModel AprobadosViewModel)
        {
            var item = _mapper.Map<tbAprobados>(AprobadosViewModel);
            var result = _licenciaServivce.EliminarAprobado(item);
            return Ok(result);
        }
    }
}
