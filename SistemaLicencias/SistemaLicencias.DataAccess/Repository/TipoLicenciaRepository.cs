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
            throw new NotImplementedException();
        }

        public VW_tbTiposLicencias_View Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbTiposLicencias item)
        {
          
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@tili_Descripcion", item.tili_Descripcion, DbType.String, ParameterDirection.Input);
            parametros.Add("@tili_UsuCreacion", item.tili_UsuCreacion, DbType.Int32, ParameterDirection.Input);


            return  db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbTiposLicencias_Insert, parametros, commandType: System.Data.CommandType.StoredProcedure);

        }

        public IEnumerable<VW_tbTiposLicencias_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbTiposLicencias_View>(ScriptsDataBase.UDP_tbTiposLicencias_Select, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbTiposLicencias item)
        {
            throw new NotImplementedException();
        }
    }
}
