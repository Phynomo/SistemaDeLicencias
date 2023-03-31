using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWRechazadosViewModel
    {
        [Display(Name = "Id")]
        public int rech_Id { get; set; }
        [Display(Name = "Id")]
        public int stud_Id { get; set; }
        [Display(Name = "Id")]
        public int soli_Id { get; set; }
        [Display(Name = "Nombre del Solicitante")]
        public string soli_Nombre { get; set; }
        [Display(Name = "Apellido del solicitante")]
        public string soli_Apellido { get; set; }
        [Display(Name = "Nombre completo del solicitante")]
        public string soli_NombreCompleto { get; set; }
        [Display(Name = "DNI")]
        public string soli_Identidad { get; set; }
        [Display(Name = "Sexo")]
        public string soli_Sexo { get; set; }
        [Display(Name = "Id")]
        public int tili_Id { get; set; }
        [Display(Name = "Licecia")]
        public string tili_Descripcion { get; set; }
        [Display(Name = "Sucursal")]
        public int sucu_Id { get; set; }
        [Display(Name = "Sucursal")]
        public string sucu_Nombre { get; set; }
        [Display(Name = "Id")]
        public int empe_Id { get; set; }
        [Display(Name = "Nombre del empleado")]
        public string empe_Nombres { get; set; }
        [Display(Name = "Apellido del empleado")]
        public string empe_Apellidos { get; set; }
        [Display(Name = "Nombre completo del empleado")]
        public string empe_NombreCompleto { get; set; }
        [Display(Name = "Obsercaciones")]
        public string rech_Observaciones { get; set; }
        [Display(Name = "Fecha")]
        public DateTime rech_Fecha { get; set; }
        [Display(Name = "Id")]
        public int rech_UsuCreacion { get; set; }
        [Display(Name = "Id")]
        public string UsuarioCreacion { get; set; }
        [Display(Name = "Id")]
        public DateTime rech_FechaCreacion { get; set; }
        [Display(Name = "Id")]
        public int? rech_UsuModificacion { get; set; }
        [Display(Name = "Id")]
        public string UsuarioModificacion { get; set; }
        [Display(Name = "Id")]
        public DateTime? rech_FechaModificacion { get; set; }
        [Display(Name = "Id")]
        public bool rech_Estado { get; set; }


    }
}
