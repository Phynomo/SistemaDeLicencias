using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class RechazadosViewModel
    {
        public int rech_Id { get; set; }
        public int stud_Id { get; set; }
        public int empe_Id { get; set; }
        public string rech_Observaciones { get; set; }
        public DateTime rech_Fecha { get; set; }
        public int rech_UsuCreacion { get; set; }
        public DateTime rech_FechaCreacion { get; set; }
        public int? rech_UsuModificacion { get; set; }
        public DateTime? rech_FechaModificacion { get; set; }
        public bool? rech_Estado { get; set; }
    }
}
