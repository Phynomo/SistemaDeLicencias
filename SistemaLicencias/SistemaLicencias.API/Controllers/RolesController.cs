//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using SistemaLicencias.BusinessLogic.Service;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SistemaLicencias.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RolesController : Controller
//    {
//        private readonly SeguService _seguridadServivce;
//        private readonly IMapper _mapper;

//        public RolesController(SeguService seguridadService, IMapper mapper)
//        {
//            _seguridadServivce = seguridadService;
//            _mapper = mapper;
//        }


//        [HttpGet("Listado")]
//        public IActionResult List()
//        {
//            var list = _seguridadServivce.Login();
//            return Ok(list);
//        }
//    }
//}
