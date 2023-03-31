using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.API.models
{
    public class AprobadosViewModel
    {
        public int apro_Id { get; set; }
        public int stud_Id { get; set; }
        public int empe_Id { get; set; }
        public string apro_Observaciones { get; set; }
        public int apro_Intentos { get; set; }
        public DateTime apro_Fecha { get; set; }
        public int apro_UsuCreacion { get; set; }
        public DateTime apro_FechaCreacion { get; set; }
        public int? apro_UsuModificacion { get; set; }
        public DateTime? apro_FechaModificacion { get; set; }
        public bool? apro_Estado { get; set; }

    }
}
