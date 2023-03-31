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
    public class RechazadosController : Controller
    {

        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public RechazadosController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoRechzados();
            return Ok(list);
        }

        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {
            var list = _licenciaServivce.BuscarRechzados(id);
            return Ok(list);
        }

        [HttpGet("ListadoxSolicitud")]
        public IActionResult ListXSoli(int stud_Id)
        {
            var list = _licenciaServivce.ListadoXSolicitud(stud_Id);
            return Ok(list);
        }

    }
}
