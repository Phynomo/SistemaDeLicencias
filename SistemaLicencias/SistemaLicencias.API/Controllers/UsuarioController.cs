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
            var list = _seguridadServivce.ListadoUsuarios();
            return Ok(list);
        }


        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {
            var list = _seguridadServivce.BuscarUsuario(id);
            return Ok(list);
        }

        [HttpPost("Insertar")]
        public IActionResult Insert(UsuariosViewModel usuarios)
        {

            var item = _mapper.Map<tbUsuarios>(usuarios);
            var response = _seguridadServivce.InsertarUsuario(item);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public IActionResult Update(UsuariosViewModel usuarios)
        {
            var item = _mapper.Map<tbUsuarios>(usuarios);
            var result = _seguridadServivce.EditarUsuario(item);
            return Ok(result);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(UsuariosViewModel usuarios)
        {
            var item = _mapper.Map<tbUsuarios>(usuarios);
            var result = _seguridadServivce.EliminarUsuario(item);
            return Ok(result);
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


        [HttpGet("RolDropDownList")]
        public IActionResult RolDropDownList()
        {
            var list = _seguridadServivce.RolDropDownList();
            return Ok(list);
        }


        [HttpGet("RolDropDownList")]
        public IActionResult RolDropDownList()
        {
            var list = _seguridadServivce.RolDropDownList();
            return Ok(list);
        }


        [HttpPut("PantallasMenu")]
        public IActionResult GenerarMenu(PantallaViewModel pantalla)
        {
            var item = _mapper.Map<tbPantallas>(pantalla);
            var list = _seguridadServivce.ListadoMenu(item);
            return Ok(list);
        }
    }
}
