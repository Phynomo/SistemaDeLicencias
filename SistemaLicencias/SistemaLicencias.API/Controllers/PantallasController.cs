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
    public class PantallasController : Controller
    {

        private readonly SeguService _seguridadServivce;
        private readonly IMapper _mapper;

        public PantallasController(SeguService seguridadService, IMapper mapper)
        {
            _seguridadServivce = seguridadService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _seguridadServivce.ListadoPantallas();
            return Ok(list);
        }
    }
}
