﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class VW_tbSolicitantes_View
    {
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public string soli_Apellido { get; set; }
        public string soli_NombreCompleto { get; set; }
        public string soli_Identidad { get; set; }
        public string soli_Sexo { get; set; }
        public DateTime soli_FechaNacimiento { get; set; }
        public string soli_Telefono { get; set; }
        public int muni_Id { get; set; }
        public string muni_Nombre { get; set; }
        public int depa_Id { get; set; }
        public string depa_Nombre { get; set; }
        public string soli_Direccion { get; set; }
        public int soli_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? soli_FechaCreacion { get; set; }
        public int? soli_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? soli_FechaModificacion { get; set; }
        public bool? soli_Estado { get; set; }
    }
}