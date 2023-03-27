using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class ScriptsDataBase
    {

        #region DROP DOWN LIST

        public static string UDP_tbDepartamentos_DDL = "gral.UDP_tbDepartamentos_DDL";
        public static string UDP_tbMunicipios_DDL = "gral.UDP_tbMunicipios_DDL";

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





    }
}
