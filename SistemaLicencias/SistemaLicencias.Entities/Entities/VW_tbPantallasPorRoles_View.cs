﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class VW_tbPantallasPorRoles_View
    {
        public int prol_Id { get; set; }
        public int role_Id { get; set; }
        public string role_Nombre { get; set; }
        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_Url { get; set; }
        public string pant_Menu { get; set; }
        public string pant_HtmlId { get; set; }
        public int prol_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime prol_FechaCreacion { get; set; }
        public int? prol_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? prol_FechaModificacion { get; set; }
        public bool prol_Estado { get; set; }
    }
}