using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class AprobadosRepository : IRepository<tbAprobados, VW_tbAprobados_View>
    {
        public RequestStatus Delete(tbAprobados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@apro_Id", item.apro_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbAprovados_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public VW_tbAprobados_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@apro_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbAprobados_View>(ScriptsDataBase.UDP_tbAprovados_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Insert(tbAprobados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbAprobados_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbAprobados_View>(ScriptsDataBase.UDP_tbAprovados_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbAprobados item)
        {
            throw new NotImplementedException();
        }
    }
}
