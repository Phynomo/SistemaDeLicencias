﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class tbTiposLicencias
    {
        public tbTiposLicencias()
        {
            tbSolicitud = new HashSet<tbSolicitud>();
        }

        public int tili_Id { get; set; }
        public string tili_Descripcion { get; set; }
        public int tili_UsuCreacion { get; set; }
        public DateTime? tili_FechaCreacion { get; set; }
        public int? tili_UsuModificacion { get; set; }
        public DateTime? tili_FechaModificacion { get; set; }
        public bool? tili_Estado { get; set; }

        public virtual tbUsuarios tili_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios tili_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbSolicitud> tbSolicitud { get; set; }
    }
}