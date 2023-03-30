using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class ScriptsDataBase
    {

        #region DROP DOWN LIST

        public static string UDP_tbDepartamentos_DDL    = "gral.UDP_tbDepartamentos_DDL";
        public static string UDP_tbMunicipios_DDL       = "gral.UDP_tbMunicipios_DDL";
        public static string UDP_tbTipoLicencis_DDL     = "lice.UDP_tbTipoLicencis_DDL";
        public static string UDP_tbSolicitantes_DDL     = "lice.UDP_tbSolicitantes_DDL";
        public static string UDP_tbRoles_DDL            = "acce.UDP_tbRoles_Select";



        public static string UDP_tbCargos_Listado           = "lice.UDP_tbCargos_SELECT";
        public static string UDP_tbSucursales_Listado       = "lice.UDP_tbSucursales_SELECT";
        public static string UDP_tbEstadosCiviles_Listado   = "gral.UDP_tbEstadosCiviles_SELECT";

        #endregion


        public static string UDP_tbTiposLicencias_Listado   = "lice.UDP_tbTiposLicencias_Select";
        public static string UDP_tbTiposLicencias_Insertar  = "lice.UDP_tbTiposLicencias_Insert";
        public static string UDP_tbTiposLicencias_Editar    = "lice.UDP_tbTiposLicencias_Update";
        public static string UDP_tbTiposLicencias_Eliminar  = "lice.UDP_tbTiposLicencias_Delete";
        public static string UDP_tbTiposLicencias_Buscar    = "lice.UDP_VW_tbTiposLicencias_View_FIND";


        #region Solicitantes
        public static string UDP_tbSolicitantes_Insertar    = "lice.UDP_tbSolicitantes_INSERT";
        public static string UDP_tbSolicitantes_Editar      = "lice.UDP_tbSolicitantes_UPDATE";
        public static string UDP_tbSolicitantes_Eliminar    = "lice.UDP_tbSolicitantes_DELETE";
        public static string UDP_tbSolicitantes_Listado     = "lice.UDP_tbSolicitantes_SELECT";
        public static string UDP_tbSolicitantes_Buscar      = "lice.UDP_VW_tbSolicitantes_View_FIND";
        #endregion



        #region Solicitud
        public static string UDP_tbSolicitud_Insertar       = "lice.UDP_tbSolicitud_INSERT";
        public static string UDP_tbSolicitud_Editar         = "lice.UDP_tbSolicitud_UPDATE";
        public static string UDP_tbSolicitud_Eliminar       = "lice.UDP_tbSolicitud_DELETE";
        public static string UDP_tbSolicitud_Listado        = "lice.UDP_tbSolicitud_SELECT";
        public static string UDP_tbSolicitud_Buscar         = "lice.UDP_VW_tbSolicitud_View_FIND";
        public static string UDP_tbSolicitud_Rechazar       = "lice.UDP_tbSolicitud_REJECT";
        public static string UDP_tbSolicitud_ACCEPT         = "lice.UDP_tbSolicitud_ACCEPT";



        #endregion



        #region Empleados
        public static string UDP_tbEmpleados_Listado = "lice.UDP_tbEmpleados_Select";
        public static string UDP_tbEmpleados_Insertar = "lice.UDP_tbEmpleados_Insert";
        public static string UDP_tbEmpleados_Editar = "lice.UDP_tbEmpleados_Update";
        public static string UDP_tbEmpleados_Eliminar = "lice.UDP_tbEmpleados_Delete";
        public static string UDP_tbEmpleados_Buscar = "lice.UDP_tbEmpleados_Find";
        #endregion

        #region Usuarios
        public static string UDP_tbAprovados_Login = "acce.UDP_IniciarSesion";
        public static string UDP_tbAprovados_Recuperar = "acce.UDP_RecuperarUsuario";
        public static string UDP_tbRolesPorPantallaMenu = "acce.tbRolesPorPantallaMenu";




        public static string UDP_tbusuarios_Insertar        = "acce.UDP_tbusuarios_INSERT";
        public static string UDP_tbusuarios_Editar          = "acce.UDP_tbusuarios_UPDATE";
        public static string UDP_tbusuarios_Eliminar        = "acce.UDP_tbusuarios_DELETE";
        public static string UDP_tbUsuarios_Listado         = "acce.UDP_tbUsuarios_SELECT";
        public static string UDP_tbUsuarios_Buscar          = "acce.UDP_VW_tbUsuarios_View_FIND";
        #endregion



        public static string UDP_tbAprovados_Listado = "lice.UDP_tbAprovados_SELECT";
        public static string UDP_tbAprovados_Buscar = "lice.UDP_tbAprovados_Find";
        public static string UDP_tbAprovados_Eliminar = "lice.UDP_tbAprobados_DELETE";

        public static string UDP_tbRechazados_Listado = "lice.UDP_tbRechazados_SELECT";
        public static string UDP_tbRechazados_ListadoXSolicitud = "lice.UDP_tbRechazados_SELECTXSolicitud";
        public static string UDP_tbRechazados_Buscar = "lice.UDP_tbRechazados_Find";


    }
}
