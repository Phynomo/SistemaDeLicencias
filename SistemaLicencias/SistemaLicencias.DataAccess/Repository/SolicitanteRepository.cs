using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class SolicitanteRepository : IRepository<tbSolicitantes, VW_tbSolicitantes_View>
    {
        public RequestStatus Delete(tbSolicitantes item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@soli_Id", item.soli_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitantes_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public VW_tbSolicitantes_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@soli_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbSolicitantes_View>(ScriptsDataBase.UDP_tbSolicitantes_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);

        }

        public RequestStatus Insert(tbSolicitantes item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@soli_Nombre",          item.soli_Nombre,           DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Apellido",        item.soli_Apellido,         DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Identidad",       item.soli_Identidad,        DbType.String,  ParameterDirection.Input);
            parametros.Add("@muni_Id",              item.muni_Id,               DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@soli_Sexo",            item.soli_Sexo,             DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_FechaNacimiento", item.soli_FechaNacimiento,  DbType.Date,    ParameterDirection.Input);
            parametros.Add("@soli_Direccion",       item.soli_Direccion,        DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Telefono",        item.soli_Telefono,         DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_UsuCreacion",     item.soli_UsuCreacion,      DbType.Int32,   ParameterDirection.Input);


            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitantes_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<VW_tbSolicitantes_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbSolicitantes_View>(ScriptsDataBase.UDP_tbSolicitantes_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbSolicitantes item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@soli_Id",              item.soli_Id,               DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@soli_Nombre",          item.soli_Nombre,           DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Apellido",        item.soli_Apellido,         DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Identidad",       item.soli_Identidad,        DbType.String,  ParameterDirection.Input);
            parametros.Add("@muni_Id",              item.muni_Id,               DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@soli_Sexo",            item.soli_Sexo,             DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_FechaNacimiento", item.soli_FechaNacimiento,  DbType.Date,    ParameterDirection.Input);
            parametros.Add("@soli_Direccion",       item.soli_Direccion,        DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_Telefono",        item.soli_Telefono,         DbType.String,  ParameterDirection.Input);
            parametros.Add("@soli_UsuModificacion", item.soli_UsuModificacion,  DbType.Int32,   ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitantes_Editar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }


        public IEnumerable<tbDepartamentos> DepartamentosDropDownList()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbDepartamentos>(ScriptsDataBase.UDP_tbDepartamentos_DDL, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public IEnumerable<tbMunicipios> MunicipiosDropDownList(int id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();

            parametros.Add("@depa_Id", id,  DbType.Int32,   ParameterDirection.Input);

            return db.Query<tbMunicipios>(ScriptsDataBase.UDP_tbMunicipios_DDL, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
