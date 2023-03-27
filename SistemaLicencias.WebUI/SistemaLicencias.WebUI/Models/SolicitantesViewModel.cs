using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class SolicitantesViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public int soli_Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Apellido { get; set; }

        [Display(Name = "Identidad")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Identidad { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Sexo { get; set; }


        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public DateTime soli_FechaNacimiento { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Telefono { get; set; }


        [Display(Name = "Municipio")]
        public int muni_Id { get; set; }

        [Display(Name = "Departameto")]
        [NotMapped]
        public int depa_Id { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "Campo '{0}' requerido")]
        public string soli_Direccion { get; set; }

    
        public int soli_UsuCreacion { get; set; }
        public DateTime? soli_FechaCreacion { get; set; }
        public int? soli_UsuModificacion { get; set; }
        public DateTime? soli_FechaModificacion { get; set; }
        public bool? soli_Estado { get; set; }



        

        [NotMapped]
        public string depa_Nombre { get; set; }



    }
}
