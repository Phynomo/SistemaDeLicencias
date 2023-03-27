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
    public class EmpleadoController : Controller
    {
        private readonly LicenciaServivce _licenciaServivce;
        private readonly IMapper _mapper;

        public EmpleadoController(LicenciaServivce licenciaServivce, IMapper mapper)
        {
            _licenciaServivce = licenciaServivce;
            _mapper = mapper;
        }



        [HttpGet("Listado")]
        public IActionResult List()
        {
            var list = _licenciaServivce.ListadoEmpleados();
            return Ok(list);
        }

        [HttpGet("Buscar")]
        public IActionResult Find(int? id)
        {
            var list = _licenciaServivce.BuscarEmpleado(id);
            return Ok(list);
        }


        [HttpPost("Insertar")]
        public IActionResult Insert(EmpleadoViewModel empleadoViewModel)
        {

            var item = _mapper.Map<tbEmpleados>(empleadoViewModel);
            var response = _licenciaServivce.InsertarEmpleado(item);
            return Ok(response);
        }

        [HttpPut("Editar")]
        public IActionResult Update(EmpleadoViewModel empleadoViewModel)
        {
            var item = _mapper.Map<tbEmpleados>(empleadoViewModel);
            var result = _licenciaServivce.EditarEmpleado(item);
            return Ok(result);
        }

        [HttpPut("Eliminar")]
        public IActionResult Delete(EmpleadoViewModel empleadoViewModel)
        {
            var item = _mapper.Map<tbEmpleados>(empleadoViewModel);
            var result = _licenciaServivce.EliminarEmpleado(item);
            return Ok(result);
        }

    }
}
