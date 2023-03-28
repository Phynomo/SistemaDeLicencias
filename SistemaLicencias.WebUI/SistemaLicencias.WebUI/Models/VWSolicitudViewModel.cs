using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWSolicitudViewModel
    {
        [Display(Name = "Id")]
        public int stud_Id { get; set; }
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public string soli_Apellido { get; set; }

        [Display(Name = "Nombre Completo")]
        public string soli_NombreCompleto { get; set; }
        public int sucu_Id { get; set; }

        [Display(Name = "Sucursal")]
        public string sucu_Nombre { get; set; }
        public int tili_Id { get; set; }

        [Display(Name = "Tipo Licencia")]
        public string tili_Descripcion { get; set; }

        [Display(Name = "Pago")]
        public bool stud_Pago { get; set; }

        [Display(Name = "Intentos")]
        public int stud_Intentos { get; set; }
        public int stud_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime stud_FechaCreacion { get; set; }
        public int? stud_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? stud_FechaModificacion { get; set; }
        public bool stud_Estado { get; set; }
    }
}
