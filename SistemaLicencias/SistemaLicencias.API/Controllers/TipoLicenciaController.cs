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
    public class TipoLicenciaController : ControllerBase
    {

        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public TipoLicenciaController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }



        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoTipoLicencia();
            return Ok(list);
        }



        [HttpPost("Insert")]
        public IActionResult Insert(TipoLicenciaViewModel tipoLicenciaViewModel)
        {

            var item = _mapper.Map<tbTiposLicencias>(tipoLicenciaViewModel);
            var response = _licenciaServivce.InsertarTipoLicencia(item);
            return Ok(response);
        }
    }
}
