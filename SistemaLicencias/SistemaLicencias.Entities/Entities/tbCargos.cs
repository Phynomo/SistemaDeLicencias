﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class tbCargos
    {
        public tbCargos()
        {
            tbEmpleados = new HashSet<tbEmpleados>();
        }

        public int carg_Id { get; set; }
        public string carg_Descripcion { get; set; }
        public int carg_UsuCreacion { get; set; }
        public DateTime? carg_FechaCreacion { get; set; }
        public int? carg_UsuModificacion { get; set; }
        public DateTime? carg_FechaModificacion { get; set; }
        public bool? carg_Estado { get; set; }

        public virtual tbUsuarios carg_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios carg_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleados { get; set; }
    }
}