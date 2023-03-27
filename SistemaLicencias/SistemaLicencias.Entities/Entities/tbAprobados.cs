﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class tbAprobados
    {
        public int apro_Id { get; set; }
        public int stud_Id { get; set; }
        public int empe_Id { get; set; }
        public bool apro_Aceptado { get; set; }
        public string apro_Observaciones { get; set; }
        public DateTime apro_Fecha { get; set; }
        public int apro_UsuCreacion { get; set; }
        public DateTime apro_FechaCreacion { get; set; }
        public int? apro_UsuModificacion { get; set; }
        public DateTime? apro_FechaModificacion { get; set; }
        public bool? apro_Estado { get; set; }

        public virtual tbUsuarios apro_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios apro_UsuModificacionNavigation { get; set; }
        public virtual tbEmpleados empe { get; set; }
        public virtual tbSolicitud stud { get; set; }
    }
}