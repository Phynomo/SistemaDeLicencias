using AutoMapper;
using SistemaLicencias.API.models;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.API.Extensions
{
    public class MappingProfileExntensions : Profile
    {
        public MappingProfileExntensions()
        {
            CreateMap<TipoLicenciaViewModel, tbTiposLicencias>().ReverseMap();
            CreateMap<SolicitanteViewModel, tbSolicitantes>().ReverseMap();
            CreateMap<EmpleadoViewModel, tbEmpleados>().ReverseMap();
            CreateMap<AprobadosViewModel, tbAprobados>().ReverseMap();
            CreateMap<UsuariosViewModel, tbUsuarios>().ReverseMap();
            CreateMap<SolicitudViewModel, tbSolicitud>().ReverseMap();
            CreateMap<RechazadosViewModel, tbRechazados>().ReverseMap();
            CreateMap<RolesViewModel, tbRoles>().ReverseMap();
            CreateMap<PantallaViewModel, tbPantallas>().ReverseMap();


        }
    }
}
