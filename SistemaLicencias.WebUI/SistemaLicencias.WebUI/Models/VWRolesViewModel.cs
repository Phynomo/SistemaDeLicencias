using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWRolesViewModel
    {
        [Display(Name="Id")]
        public int role_Id { get; set; }
        [Display(Name = "Rol")]
        public string role_Nombre { get; set; }
        [Display(Name = "Usuario creacion")]
        public int role_UsuCreacion { get; set; }
        [Display(Name = "Usuario creacion")]
        public string UsuarioCreacion { get; set; }
        [Display(Name = "Fecha creacion")]
        public DateTime role_FechaCreacion { get; set; }
        [Display(Name = "Usuario Modificacion")]
        public int? role_UsuModificacion { get; set; }
        [Display(Name = "Usuario modificacion ")]
        public string UsuarioModificacion { get; set; }
        [Display(Name = "Fecha Modificacion")]
        public DateTime? role_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool role_Estado { get; set; }

        public string[] pantallas { get; set; }
    }
}
