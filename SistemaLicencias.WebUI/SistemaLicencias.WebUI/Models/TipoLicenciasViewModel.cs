using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class TipoLicenciasViewModel
    {
        [Display(Name = "Id")]
        public int tili_Id { get; set; }
        [Display(Name = "Tipo de Licencia")]
        public string tili_Descripcion { get; set; }
        [Display(Name = "Usuario Creacion")]
        public int tili_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creacion")]
        public DateTime? tili_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? tili_UsuModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? tili_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool? tili_Estado { get; set; }

    }
}
