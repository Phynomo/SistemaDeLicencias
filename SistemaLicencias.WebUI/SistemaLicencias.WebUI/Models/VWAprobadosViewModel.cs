using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWAprobadosViewModel
    {
        [Display(Name = "Id")]
        public int apro_Id { get; set; }
        [Display(Name = "Id")]
        public int stud_Id { get; set; }
        [Display(Name = "Id")]
        public int soli_Id { get; set; }
        [Display(Name = "Nombre del solicitante")]
        public string soli_Nombre { get; set; }
        [Display(Name = "Apellido del solicitante")]
        public string soli_Apellido { get; set; }
        [Display(Name = "Nombre completo del solicitante")]
        public string soli_NombreCompleto { get; set; }
        [Display(Name = "DNI del solicitante")]
        public string soli_Identidad { get; set; }
        [Display(Name = "Sexo")]
        public string soli_Sexo { get; set; }
        [Display(Name = "Licencia")]
        public int tili_Id { get; set; }
        [Display(Name = "Descripcion")]
        public string tili_Descripcion { get; set; }
        [Display(Name = "Sucursal")]
        public int sucu_Id { get; set; }
        [Display(Name = "Sucursal")]
        public string sucu_Nombre { get; set; }
        [Display(Name = "Id")]
        public int empe_Id { get; set; }
        [Display(Name = "Nombre del empleado")]
        public string empe_Nombres { get; set; }
        [Display(Name = "Apelldio del empleado")]
        public string empe_Apellidos { get; set; }
        [Display(Name = "Nombre completo del empleado")]
        public string empe_NombreCompleto { get; set; }
        [Display(Name = "Observaciones")]
        public string apro_Observaciones { get; set; }
        [Display(Name = "N° de Intentos")]
        public int apro_Intentos { get; set; }
        [Display(Name = "Fecha de aprovacion")]
        public DateTime apro_Fecha { get; set; }
        [Display(Name = "Id")]
        public int apro_UsuCreacion { get; set; }
        [Display(Name = "Id")]
        public string UsuarioCreacion { get; set; }
        [Display(Name = "Id")]
        public DateTime apro_FechaCreacion { get; set; }
        [Display(Name = "Id")]
        public int? apro_UsuModificacion { get; set; }
        [Display(Name = "Id")]
        public string UsuarioModificacion { get; set; }
        [Display(Name = "Id")]
        public DateTime? apro_FechaModificacion { get; set; }
        [Display(Name = "Id")]
        public bool apro_Estado { get; set; }


    }
}
