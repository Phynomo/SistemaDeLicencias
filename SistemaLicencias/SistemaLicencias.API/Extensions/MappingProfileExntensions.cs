﻿using AutoMapper;
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
        }
    }
}
