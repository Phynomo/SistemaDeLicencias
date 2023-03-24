using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWTiposLicenciasViewModel
    {
        public int tili_Id { get; set; }
        public string tili_Descripcion { get; set; }
        public int tili_UsuCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? tili_FechaCreacion { get; set; }
        public int? tili_UsuModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? tili_FechaModificacion { get; set; }
        public bool? tili_Estado { get; set; }

    }
}
