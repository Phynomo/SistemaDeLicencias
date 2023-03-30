using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class PantallasPorRolRepository : IRepository<tbPantallasPorRoles, VW_tbPantallasPorRoles_View>
    {
        public RequestStatus Delete(tbPantallasPorRoles item)
        {
            RequestStatus resul = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros2 = new DynamicParameters();
            parametros2.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);

            var resultado = db.QueryFirst<int>(ScriptsDataBase.UDP_tbPantallasXRoles_Eliminar, parametros2, commandType: System.Data.CommandType.StoredProcedure);

            resul.CodeStatus = resultado;

            return resul;
        }

        public VW_tbPantallasPorRoles_View Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbPantallasPorRoles item)
        {
            RequestStatus resul = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
           
            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@pant_Id", item.pant_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@prol_UsuCreacion", item.prol_UsuCreacion, DbType.Int32, ParameterDirection.Input);

            var resultado = db.QueryFirst<int>(ScriptsDataBase.UDP_tbPantallasXRoles_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            resul.CodeStatus = resultado;

            return resul;
        }

        public IEnumerable<VW_tbPantallasPorRoles_View> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbPantallasPorRoles_View> ListPxRxR(int? role_Id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", role_Id, DbType.Int32, ParameterDirection.Input);

            return db.Query<VW_tbPantallasPorRoles_View>(ScriptsDataBase.UDP_tbPantallasXRoles_ListadoPxRxR, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbPantallasPorRoles item)
        {
            throw new NotImplementedException();
        }
    }
}
