using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWRolesViewModel
    {
        public int role_Id { get; set; }
        public string role_Nombre { get; set; }
        public int role_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime role_FechaCreacion { get; set; }
        public int? role_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? role_FechaModificacion { get; set; }
        public bool role_Estado { get; set; }

        public string[] pantallas { get; set; }
    }
}
