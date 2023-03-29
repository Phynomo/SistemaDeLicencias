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
    public class RolesController : Controller
    {
        private readonly SeguService _seguridadServivce;
        private readonly IMapper _mapper;

        public RolesController(SeguService seguridadService, IMapper mapper)
        {
            _seguridadServivce = seguridadService;
            _mapper = mapper;
        }


        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _seguridadServivce.ListadoRoles();
            return Ok(list);
        }


        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {
            var list = _seguridadServivce.BuscarRoles(id);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(RolesViewModel roles)
        {

            var item = _mapper.Map<tbRoles>(roles);
            var response = _seguridadServivce.InsertarRoles(item);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public IActionResult Update(RolesViewModel roles)
        {
            var item = _mapper.Map<tbRoles>(roles);
            var result = _seguridadServivce.EditarRoles(item);
            return Ok(result);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(RolesViewModel roles)
        {
            var item = _mapper.Map<tbRoles>(roles);
            var result = _seguridadServivce.EliminarRoles(item);
            return Ok(result);
        }


    }
}
