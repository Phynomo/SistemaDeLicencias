using Dapper;
using Microsoft.Data.SqlClient;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SistemaLicencias.DataAccess.Repository
{
    public class SolicitudRepository : IRepository<tbSolicitud, VW_tbSolicitud_View>
    {
        public RequestStatus Delete(tbSolicitud item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id", item.stud_Id, DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitud_Eliminar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public VW_tbSolicitud_View Find(int? id)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id", id, DbType.Int32, ParameterDirection.Input);

            return db.QueryFirst<VW_tbSolicitud_View>(ScriptsDataBase.UDP_tbSolicitud_Buscar, parametros, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Insert(tbSolicitud item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@soli_Id",          item.soli_Id,           DbType.Int32, ParameterDirection.Input);
            parametros.Add("@sucu_Id",          item.sucu_Id,           DbType.Int32, ParameterDirection.Input);
            parametros.Add("@tili_Id",          item.tili_Id,           DbType.Int32, ParameterDirection.Input);
            parametros.Add("@stud_Pago",        item.stud_Pago,         DbType.Int32, ParameterDirection.Input);
            parametros.Add("@stud_UsuCreacion", item.stud_UsuCreacion,  DbType.Int32, ParameterDirection.Input);


            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitud_Insertar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;

        }

        public IEnumerable<VW_tbSolicitud_View> List()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<VW_tbSolicitud_View>(ScriptsDataBase.UDP_tbSolicitud_Listado, null, commandType: System.Data.CommandType.StoredProcedure);
        }

        public RequestStatus Update(tbSolicitud item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id",              item.stud_Id,               DbType.Int32, ParameterDirection.Input);
            parametros.Add("@sucu_Id",              item.sucu_Id,               DbType.Int32, ParameterDirection.Input);
            parametros.Add("@tili_Id",              item.tili_Id,               DbType.Int32, ParameterDirection.Input);
            parametros.Add("@stud_Pago",            item.stud_Pago,             DbType.Int32, ParameterDirection.Input);
            parametros.Add("@stud_UsuModificacion", item.stud_UsuModificacion,  DbType.Int32, ParameterDirection.Input);


            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitud_Editar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Reject(tbRechazados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id",              item.stud_Id,               DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@empe_Id",              item.empe_Id,               DbType.Int32,   ParameterDirection.Input);
            parametros.Add("@rech_Observaciones",   item.rech_Observaciones,    DbType.String,  ParameterDirection.Input);
            parametros.Add("@rech_UsuCreacion",     item.rech_UsuCreacion,      DbType.Int32,   ParameterDirection.Input);
            
            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitud_Rechazar, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }

        public RequestStatus Accept(tbAprobados item)
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            var parametros = new DynamicParameters();
            parametros.Add("@stud_Id",              item.stud_Id,               DbType.Int32, ParameterDirection.Input);
            parametros.Add("@empe_Id",              item.empe_Id,               DbType.Int32, ParameterDirection.Input);
            parametros.Add("@apro_Observaciones",   item.apro_Observaciones,    DbType.String, ParameterDirection.Input);
            parametros.Add("@apro_UsuCreacion",     item.apro_UsuCreacion,      DbType.Int32, ParameterDirection.Input);

            var result = db.QueryFirst<RequestStatus>(ScriptsDataBase.UDP_tbSolicitud_ACCEPT, parametros, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }



        public IEnumerable<tbTiposLicencias> TipoLicenciaDropDownList()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbTiposLicencias>(ScriptsDataBase.UDP_tbTipoLicencis_DDL, null, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<tbSolicitantes> SolicitanteDropDownList()
        {
            using var db = new SqlConnection(LicenciaContext.ConnectionString);
            return db.Query<tbSolicitantes>(ScriptsDataBase.UDP_tbSolicitantes_DDL, null, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
