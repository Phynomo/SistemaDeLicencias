using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class AprobadosRepository : IRepository<tbAprobados, VW_tbAprobados_View>
    {
        public RequestStatus Delete(tbAprobados item)
        {
            throw new NotImplementedException();
        }

        public VW_tbAprobados_View Find(int? id)
        {
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbAprobados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbAprobados_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbAprobados_View>(ScriptsDataBase.UDP_tbEmpleados_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbAprobados item)
        {
            throw new NotImplementedException();
        }
    }
}
