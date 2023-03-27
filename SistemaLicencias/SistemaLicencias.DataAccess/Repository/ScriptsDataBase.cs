using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class ScriptsDataBase
    {
        public static string UDP_tbTiposLicencias_Listado = "lice.UDP_tbTiposLicencias_Select";
        public static string UDP_tbTiposLicencias_Insertar = "lice.UDP_tbTiposLicencias_Insert";
        public static string UDP_tbTiposLicencias_Editar = "lice.UDP_tbTiposLicencias_Update";
        public static string UDP_tbTiposLicencias_Eliminar = "lice.UDP_tbTiposLicencias_Delete";
        public static string UDP_tbTiposLicencias_Buscar = "lice.UDP_VW_tbTiposLicencias_View_FIND";




        #region Empleados
        public static string UDP_tbEmpleados_Listado = "lice.UDP_tbEmpleados_Select";
        public static string UDP_tbEmpleados_Insertar = "lice.UDP_tbEmpleados_Insert";
        public static string UDP_tbEmpleados_Editar = "lice.UDP_tbEmpleados_Update";
        public static string UDP_tbEmpleados_Eliminar = "lice.UDP_tbEmpleados_Delete";
        public static string UDP_tbEmpleados_Buscar = "lice.UDP_tbEmpleados_Find";
        #endregion




        public static string UDP_tbCargos_Listado = "lice.UDP_tbCargos_SELECT";
        public static string UDP_tbSucursales_Listado = "lice.UDP_tbSucursales_SELECT";
        public static string UDP_tbEstadosCiviles_Listado = "gral.UDP_tbEstadosCiviles_SELECT";
    }
}
