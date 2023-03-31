using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class RolesRepository : IRepository<tbRoles, VW_tbRoles_View>
    {
        public RequestStatus Delete(tbRoles item)
        {
            RequestStatus resul = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            var resultado = db.QueryFirst<int>(ScriptsDataBase.UDP_tbRoles_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            resul.CodeStatus = resultado;

            return resul;
        }

        public VW_tbRoles_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbRoles_View>(ScriptsDataBase.UDP_tbRoles_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);

        }

        public RequestStatus Insert(tbRoles item)
        {
            RequestStatus resul = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@role_UsuCreacion", item.role_UsuCreacion, DbType.Int32, ParameterDirection.Input);

            var resultado = db.QueryFirst<int>(ScriptsDataBase.UDP_tbRoles_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            resul.CodeStatus = resultado;

            return resul;

        }

        public IEnumerable<VW_tbRoles_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbRoles_View>(ScriptsDataBase.UDP_tbRoles_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbRoles item)
        {
            RequestStatus resul = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@role_Id", item.role_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@role_Nombre", item.role_Nombre, DbType.String, ParameterDirection.Input);
            parametros.Add("@role_UsuModificacion", item.role_UsuModificacion, DbType.Int32, ParameterDirection.Input);

            var resultado = db.QueryFirst<int>(ScriptsDataBase.UDP_tbRoles_Editar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            resul.CodeStatus = resultado;

            return resul;

        }
    }
}
