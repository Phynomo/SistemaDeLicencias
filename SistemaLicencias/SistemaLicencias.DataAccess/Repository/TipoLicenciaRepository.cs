using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class TipoLicenciaRepository : IRepository<tbTiposLicencias, VW_tbTiposLicencias_View> 
    {
        public RequestStatus Delete(tbTiposLicencias item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@tili_Id", item.tili_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbTiposLicencias_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public VW_tbTiposLicencias_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@tili_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbTiposLicencias_View>(ScriptsDataBase.UDP_tbTiposLicencias_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);

        }

        public RequestStatus Insert(tbTiposLicencias item)
        {
            RequestStatus result = new RequestStatus();
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@tili_Descripcion", item.tili_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@tili_UsuCreacion", item.tili_UsuCreacion, DbType.Int32, ParameterDirection.Input);


            var respuesta = db.QueryFirst<int>(ScriptsDataBase.UDP_tbTiposLicencias_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);

            result.CodeStatus = respuesta;

            return result;
        }

        public IEnumerable<VW_tbTiposLicencias_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbTiposLicencias_View>(ScriptsDataBase.UDP_tbTiposLicencias_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbTiposLicencias item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@tili_Id", item.tili_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@tili_Descripcion", item.tili_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@tili_UsuModificacion", item.tili_UsuModificacion, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbTiposLicencias_Editar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


    }
}
