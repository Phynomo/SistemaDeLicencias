using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.API.models
{
    public class SolicitudViewModel
    {
        public int stud_Id { get; set; }
        public int soli_Id { get; set; }
        public int sucu_Id { get; set; }
        public int tili_Id { get; set; }
        public bool stud_Pago { get; set; }
        public int stud_Intentos { get; set; }
        public int stud_UsuCreacion { get; set; }
        public DateTime stud_FechaCreacion { get; set; }
        public int? stud_UsuModificacion { get; set; }
        public DateTime? stud_FechaModificacion { get; set; }
        public bool? stud_Estado { get; set; }
    }
}
