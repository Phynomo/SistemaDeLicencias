using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaLicencias.BusinessLogic.Service;
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


    }
}
