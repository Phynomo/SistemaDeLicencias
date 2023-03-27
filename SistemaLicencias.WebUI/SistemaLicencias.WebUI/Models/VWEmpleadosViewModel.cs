using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLicencias.WebUI.Models
{
    public class VWEmpleadosViewModel
    {
        [Display(Name = "Id")]
        public int empe_Id { get; set; }
        [Display(Name = "Nombres")]
        public string empe_Nombres { get; set; }
        [Display(Name = "Apellidos")]
        public string empe_Apellidos { get; set; }
        [Display(Name = "Nombre completo")]
        public string empe_NombreCompleto { get; set; }
        [Display(Name = "Numero de Identidad")]
        public string empe_Identidad { get; set; }
        [Display(Name = "Fecha de nacimiento")]
        public DateTime empe_FechaNacimiento { get; set; }
        [Display(Name = "Sexo")]
        public string empe_Sexo { get; set; }
        [Display(Name = "Estado Civil")]
        public int eciv_Id { get; set; }
        [Display(Name = "Estado Civil")]
        public string eciv_Descripcion { get; set; }
        [Display(Name = "Municipio")]
        public int muni_Id { get; set; }
        [Display(Name = "Codigo del municipio")]
        public string muni_Codigo { get; set; }
        [Display(Name = "Municipio")]
        public string muni_Nombre { get; set; }
        [Display(Name = "Departamento")]
        public int depa_Id { get; set; }
        [Display(Name = "Codigo del departamento")]
        public string depa_Codigo { get; set; }
        [Display(Name = "Departamento")]
        public string depa_Nombre { get; set; }
        [Display(Name = "Direccion Exacta")]
        public string empe_DireccionExacta { get; set; }
        [Display(Name = "Telefono")]
        public string empe_Telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        public string empe_CorreoElectronico { get; set; }
        [Display(Name = "Sucursal")]
        public int sucu_Id { get; set; }
        [Display(Name = "Sucursal")]
        public string sucu_Nombre { get; set; }
        [Display(Name = "Cargo")]
        public int carg_Id { get; set; }
        [Display(Name = "Cargo")]
        public string carg_Descripcion { get; set; }
        [Display(Name = "Usuario Creador")]
        public int empe_UsuCreacion { get; set; }
        [Display(Name = "Fecha Creador")]
        public string UsuarioCreacion { get; set; }
        [Display(Name = "Fecha de cracion")]
        public DateTime empe_FechaCreacion { get; set; }
        [Display(Name = "Usuarion Modificador")]
        public int? empe_UsuModificacion { get; set; }
        [Display(Name = "Usuario Modificador")]
        public string UsuarioModificacion { get; set; }
        [Display(Name = "Fecha de modificacion")]
        public DateTime? empe_FechaModificacion { get; set; }
        [Display(Name = "Estado")]
        public bool empe_Estado { get; set; }

    }
}
