using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWSolicitantesViewModel
    {
        [Display(Name = "Id")]
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public string soli_Apellido { get; set; }

        [Display(Name = "Nombre Completo")]
        public string soli_NombreCompleto { get; set; }

        [Display(Name = "Identidad")]
        public string soli_Identidad { get; set; }

        [Display(Name = "Sexo")]
        public string soli_Sexo { get; set; }


        public DateTime soli_FechaNacimiento { get; set; }

        [Display(Name = "Telefono")]
        public string soli_Telefono { get; set; }
        public int muni_Id { get; set; }

        public string muni_Nombre { get; set; }
        public int depa_Id { get; set; }
        public string depa_Nombre { get; set; }

        [Display(Name = "Direccion")]
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
