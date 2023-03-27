using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class EmpleadoRepository : IRepository<tbEmpleados, VW_tbEmpleados_View>
    {
        public RequestStatus Delete(tbEmpleados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbEmpleados_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public VW_tbEmpleados_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbEmpleados_View>(ScriptsDataBase.UDP_tbEmpleados_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Insert(tbEmpleados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);

            DateTime fechaNacimineto = Convert.ToDateTime(item.empe_FechaNacimiento);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellidos", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento", fechaNacimineto.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@eciv_Id", item.eciv_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_DireccionExacta", item.empe_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico + " ", DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_Id", item.sucu_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@carg_Id", item.carg_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_UsuCreacion", item.empe_UsuCreacion, DbType.Int32, ParameterDirection.Input);


            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbEmpleados_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<VW_tbEmpleados_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbEmpleados_View>(ScriptsDataBase.UDP_tbEmpleados_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbEmpleados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);

            DateTime fechaNacimineto = Convert.ToDateTime(item.empe_FechaNacimiento);

            var parametros = new DynamicParameters();
            parametros.Add("@empe_Id", item.empe_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Nombres", item.empe_Nombres, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Apellidos", item.empe_Apellidos, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Identidad", item.empe_Identidad, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_FechaNacimiento", fechaNacimineto.ToString("yyyy-MM-dd"), DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Sexo", item.empe_Sexo, DbType.String, ParameterDirection.Input);
            parametros.Add("@eciv_Id", item.eciv_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@muni_Id", item.muni_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_DireccionExacta", item.empe_DireccionExacta, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_Telefono", item.empe_Telefono, DbType.String, ParameterDirection.Input);
            parametros.Add("@empe_CorreoElectronico", item.empe_CorreoElectronico + " ", DbType.String, ParameterDirection.Input);
            parametros.Add("@sucu_Id", item.sucu_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@carg_Id", item.carg_Id, DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_UsuModificacion", item.empe_UsuModificacion, DbType.Int32, ParameterDirection.Input);


            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbEmpleados_Editar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }



        public IEnumerable<tbCargos> ListCargos()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbCargos>(ScriptsDataBase.UDP_tbCargos_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }
    

        public IEnumerable<tbSucursales> ListSucursales()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbSucursales>(ScriptsDataBase.UDP_tbSucursales_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }
    

        public IEnumerable<tbEstadosCiviles> ListEstadosCiviles()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbEstadosCiviles>(ScriptsDataBase.UDP_tbEstadosCiviles_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
