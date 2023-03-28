using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class UsuarioRepository : IRepository<tbUsuarios, VW_tbUsuarios_View>
    {
        public RequestStatus Delete(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public VW_tbUsuarios_View Find(int? id)
        {
            throw new NotImplementedException();
        }
        public VW_tbUsuarios_View Login(tbUsuarios item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@user_NombreUsuario", item.user_NombreUsuario, DbType.String, ParameterDirection.Input);
            parametros.Add("@user_Contrasena", item.user_Contrasena, DbType.String, ParameterDirection.Input);

            return db.QueryFirst<VW_tbUsuarios_View>(ScriptsDataBase.UDP_tbAprovados_Login, parametros, commandType: System.Data.CommandType.StoredProcedure);


        }

        public RequestStatus Insert(tbUsuarios item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VW_tbUsuarios_View> List()
        {
            throw new NotImplementedException();
        }

        public RequestStatus Update(tbUsuarios item)
        {
            throw new NotImplementedException();
        }
    }
}
