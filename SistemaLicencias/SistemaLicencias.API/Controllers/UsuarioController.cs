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
    public class UsuarioController : Controller
    {
        private readonly SeguService _seguridadServivce;
        private readonly IMapper _mapper;

        public UsuarioController(SeguService seguridadService, IMapper mapper)
        {
            _seguridadServivce = seguridadService;
            _mapper = mapper;
        }

        [HttpGet("Listado")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut("IniciarSesion")]
        public IActionResult Login(UsuariosViewModel usuariosView)
        {
            var item = _mapper.Map<tbUsuarios>(usuariosView);
            var list = _seguridadServivce.Login(item);
            return Ok(list);
        }
        
        [HttpPut("Recuperar")]
        public IActionResult Recuperar(UsuariosViewModel usuariosView)
        {
            var item = _mapper.Map<tbUsuarios>(usuariosView);
            var list = _seguridadServivce.Recuperar(item);
            return Ok(list);
        }

    }
}
