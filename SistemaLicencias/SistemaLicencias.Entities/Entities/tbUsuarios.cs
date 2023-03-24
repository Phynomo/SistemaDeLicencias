﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaLicencias.Entities.Entities
{
    public partial class tbUsuarios
    {
        public tbUsuarios()
        {
            Inverseuser_UsuCreacionNavigation = new HashSet<tbUsuarios>();
            Inverseuser_UsuModificacionNavigation = new HashSet<tbUsuarios>();
            tbAprovadosapro_UsuCreacionNavigation = new HashSet<tbAprovados>();
            tbAprovadosapro_UsuModificacionNavigation = new HashSet<tbAprovados>();
            tbCargoscarg_UsuCreacionNavigation = new HashSet<tbCargos>();
            tbCargoscarg_UsuModificacionNavigation = new HashSet<tbCargos>();
            tbDepartamentosdepa_UsuCreacionNavigation = new HashSet<tbDepartamentos>();
            tbDepartamentosdepa_UsuModificacionNavigation = new HashSet<tbDepartamentos>();
            tbEmpleadosempe_UsuCreacionNavigation = new HashSet<tbEmpleados>();
            tbEmpleadosempe_UsuModificacionNavigation = new HashSet<tbEmpleados>();
            tbEstadosCivileseciv_UsuCreacionNavigation = new HashSet<tbEstadosCiviles>();
            tbEstadosCivileseciv_UsuModificacionNavigation = new HashSet<tbEstadosCiviles>();
            tbMunicipiosmuni_UsuCreacionNavigation = new HashSet<tbMunicipios>();
            tbMunicipiosmuni_UsuModificacionNavigation = new HashSet<tbMunicipios>();
            tbPantallasPorRolespantrole_UsuCreacionNavigation = new HashSet<tbPantallasPorRoles>();
            tbPantallasPorRolespantrole_UsuModificacionNavigation = new HashSet<tbPantallasPorRoles>();
            tbRolesrole_UsuCreacionNavigation = new HashSet<tbRoles>();
            tbRolesrole_UsuModificacionNavigation = new HashSet<tbRoles>();
            tbSolicitantessoli_UsuCreacionNavigation = new HashSet<tbSolicitantes>();
            tbSolicitantessoli_UsuModificacionNavigation = new HashSet<tbSolicitantes>();
            tbSucursalessucu_UsuCreacionNavigation = new HashSet<tbSucursales>();
            tbSucursalessucu_UsuModificacionNavigation = new HashSet<tbSucursales>();
            tbTiposLicenciastili_UsuCreacionNavigation = new HashSet<tbTiposLicencias>();
            tbTiposLicenciastili_UsuModificacionNavigation = new HashSet<tbTiposLicencias>();
        }

        public int user_Id { get; set; }
        public string user_NombreUsuario { get; set; }
        public string user_Contrasena { get; set; }
        public bool? user_EsAdmin { get; set; }
        public int? role_Id { get; set; }
        public int? empe_Id { get; set; }
        public int? user_UsuCreacion { get; set; }
        public DateTime user_FechaCreacion { get; set; }
        public int? user_UsuModificacion { get; set; }
        public DateTime? user_FechaModificacion { get; set; }
        public bool? user_Estado { get; set; }

        public virtual tbRoles role { get; set; }
        public virtual tbUsuarios user_UsuCreacionNavigation { get; set; }
        public virtual tbUsuarios user_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbUsuarios> Inverseuser_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbUsuarios> Inverseuser_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbAprovados> tbAprovadosapro_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbAprovados> tbAprovadosapro_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbCargos> tbCargoscarg_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbCargos> tbCargoscarg_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbDepartamentos> tbDepartamentosdepa_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbDepartamentos> tbDepartamentosdepa_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosempe_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbEmpleados> tbEmpleadosempe_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivileseciv_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbEstadosCiviles> tbEstadosCivileseciv_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbMunicipios> tbMunicipiosmuni_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbMunicipios> tbMunicipiosmuni_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbPantallasPorRoles> tbPantallasPorRolespantrole_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbPantallasPorRoles> tbPantallasPorRolespantrole_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesrole_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbRoles> tbRolesrole_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbSolicitantes> tbSolicitantessoli_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbSolicitantes> tbSolicitantessoli_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbSucursales> tbSucursalessucu_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbSucursales> tbSucursalessucu_UsuModificacionNavigation { get; set; }
        public virtual ICollection<tbTiposLicencias> tbTiposLicenciastili_UsuCreacionNavigation { get; set; }
        public virtual ICollection<tbTiposLicencias> tbTiposLicenciastili_UsuModificacionNavigation { get; set; }
    }
}