﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class VW_tbSolicitud_View
    {
        public int stud_Id { get; set; }
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public int sucu_Id { get; set; }
        public string sucu_Nombre { get; set; }
        public int tili_Id { get; set; }
        public string tili_Descripcion { get; set; }
        public bool stud_Pago { get; set; }
        public int stud_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime stud_FechaCreacion { get; set; }
        public int? stud_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? stud_FechaModificacion { get; set; }
        public bool stud_Estado { get; set; }
    }
}