using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWPantallasPorRolesViewModel
    {
        public int prol_Id { get; set; }
        public int role_Id { get; set; }
        public string role_Nombre { get; set; }
        public int pant_Id { get; set; }
        public string pant_Nombre { get; set; }
        public string pant_Url { get; set; }
        public string pant_Menu { get; set; }
        public string pant_HtmlId { get; set; }
        public int prol_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime prol_FechaCreacion { get; set; }
        public int? prol_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? prol_FechaModificacion { get; set; }
        public bool prol_Estado { get; set; }
    }
}
