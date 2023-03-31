using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class RechazadosRepository : IRepository<tbRechazados, VW_tbRechazados_View>
    {
        public RequestStatus Delete(tbRechazados item)
        {
            throw new NotImplementedException();
        }

        public VW_tbRechazados_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbRechazados_View>(ScriptsDataBase.UDP_tbRechazados_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Insert(tbRechazados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbRechazados_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbRechazados_View>(ScriptsDataBase.UDP_tbRechazados_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbRechazados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbRechazados_View> RechazadosXSolicitud(int id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.Query<VW_tbRechazados_View>(ScriptsDataBase.UDP_tbRechazados_ListadoXSolicitud, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

    }
}
