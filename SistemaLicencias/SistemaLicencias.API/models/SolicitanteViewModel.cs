using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.API.models
{
    public class SolicitanteViewModel
    {
        public int soli_Id { get; set; }
        public string soli_Nombre { get; set; }
        public string soli_Apellido { get; set; }
        public string soli_Identidad { get; set; }
        public string soli_Sexo { get; set; }
        public DateTime soli_FechaNacimiento { get; set; }
        public string soli_Telefono { get; set; }
        public int muni_Id { get; set; }
        public string soli_Direccion { get; set; }
        public int soli_UsuCreacion { get; set; }
        public DateTime? soli_FechaCreacion { get; set; }
        public int? soli_UsuModificacion { get; set; }
        public DateTime? soli_FechaModificacion { get; set; }
        public bool? soli_Estado { get; set; }

        [NotMapped]
        public int depa_Id { get; set; }
    }
}
