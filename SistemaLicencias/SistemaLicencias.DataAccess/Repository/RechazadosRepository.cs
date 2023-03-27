using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public RequestStatus Insert(tbRechazados item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbRechazados_View> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbRechazados item)
        {
            throw new NotImplementedException();
        }
    }
}
