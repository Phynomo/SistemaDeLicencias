﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class VW_tbAprobados_View
    {
        public int apro_Id { get; set; }
        public int stud_Id { get; set; }
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public string soli_Apellido { get; set; }
        public string soli_NombreCompleto { get; set; }
        public string soli_Identidad { get; set; }
        public string soli_Sexo { get; set; }
        public int tili_Id { get; set; }
        public string tili_Descripcion { get; set; }
        public int sucu_Id { get; set; }
        public string sucu_Nombre { get; set; }
        public int empe_Id { get; set; }
        public string empe_Nombres { get; set; }
        public string empe_Apellidos { get; set; }
        public string empe_NombreCompleto { get; set; }
        public string apro_Observaciones { get; set; }
        public int apro_Intentos { get; set; }
        public DateTime apro_Fecha { get; set; }
        public int apro_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime apro_FechaCreacion { get; set; }
        public int? apro_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? apro_FechaModificacion { get; set; }
        public bool apro_Estado { get; set; }
    }
}