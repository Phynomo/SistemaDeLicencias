﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class tbRechazados
    {
        public int rech_Id { get; set; }
        public int stud_Id { get; set; }
        public int empe_Id { get; set; }
        public string rech_Observaciones { get; set; }
        public DateTime rech_Fecha { get; set; }
        public int rech_UsuCreacion { get; set; }
        public DateTime rech_FechaCreacion { get; set; }
        public int? rech_UsuModificacion { get; set; }
        public DateTime? rech_FechaModificacion { get; set; }
        public bool? rech_Estado { get; set; }

        public virtual tbEmpleados empe { get; set; }
        public virtual tbUsuarios rech_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios rech_UsuModificacionNavigation { get; set; }
        public virtual tbSolicitud stud { get; set; }
    }
}