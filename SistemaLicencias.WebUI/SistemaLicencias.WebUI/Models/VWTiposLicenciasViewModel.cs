using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWTiposLicenciasViewModel
    {
        [Display(Name="Id")]
        public int tili_Id { get; set; }
        [Display(Name = "Tipo de licencia")]
        public string tili_Descripcion { get; set; }
        [Display(Name = "Usuario Creador")]
        public int tili_UsuCreacion { get; set; }
        [Display(Name = "Usuario Creador")]
        public string UsuarioCreacion { get; set; }
        [Display(Name = "Fecha de creacion")]
        public DateTime? tili_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificador")]
        public int? tili_UsuModificacion { get; set; }
        [Display(Name = "Usuario Modificador")]
        public string UsuarioModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? tili_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? tili_Estado { get; set; }

    }
}
