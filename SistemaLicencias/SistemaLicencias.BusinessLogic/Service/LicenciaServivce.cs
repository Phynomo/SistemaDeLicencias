﻿using SistemaLicencias.DataAccess.Repository;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaLicencias.BusinessLogic.Service
{
    public class  LicenciaServivce
    {
        private readonly TipoLicenciaRepository _tipoLicenciaRepository;
        private readonly SolicitanteRepository  _solicitanteRepository;
        private readonly EmpleadoRepository     _empleadosRepository;
        private readonly SolicitudRepository    _solicitudRepository;

        public LicenciaServivce(TipoLicenciaRepository tipoLicenciaRepository,
                                SolicitanteRepository solicitanteRepository,
                                EmpleadoRepository empleadoRepository,
                                SolicitudRepository solicitudRepository)
        {
            _tipoLicenciaRepository = tipoLicenciaRepository;
            _solicitanteRepository  = solicitanteRepository;
            _empleadosRepository    = empleadoRepository;
            _solicitudRepository    = solicitudRepository;
        }


        #region Tipos Licencias

        //INDEX
        public ServiceResult ListadoTipoLicencia()
        {
            var result = new ServiceResult();
            try
            {
                var list = _tipoLicenciaRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {

                return result.Error(e.Message);

            }
        }
        
        
        public VW_tbTiposLicencias_View BuscarTipoLicencia(int? id)
        {
            try
            {
                var list = _tipoLicenciaRepository.Find(id);
                return list;
            }
            catch (Exception)
            {

                return null;

            }
        }

        public ServiceResult InsertarTipoLicencia(tbTiposLicencias tbTipos)
        {
            var result = new ServiceResult();
            try
            {
                var map = _tipoLicenciaRepository.Insert(tbTipos);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ServiceResult EditarTipoLicencia(tbTiposLicencias tbTipos)
        {
            var result = new ServiceResult();
            try
            {
                var map = _tipoLicenciaRepository.Update(tbTipos);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ServiceResult EliminarTipoLicencia(tbTiposLicencias tbTipos)
        {
            var result = new ServiceResult();
            try
            {
                var map = _tipoLicenciaRepository.Delete(tbTipos);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        

        #region Empleados

        //INDEX
        public ServiceResult ListadoEmpleados()
        {
            var result = new ServiceResult();
            try
            {
                var list = _empleadosRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {

                return result.Error(e.Message);

            }
        }
        
        
        public VW_tbEmpleados_View BuscarEmpleado(int? id)
        {
            try
            {
                var list = _empleadosRepository.Find(id);
                return list;
            }
            catch (Exception)
            {

                return null;

            }
        }

        public ServiceResult InsertarEmpleado(tbEmpleados tbEmpleado)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadosRepository.Insert(tbEmpleado);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        
        public ServiceResult EditarEmpleado(tbEmpleados tbEmpleado)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadosRepository.Update(tbEmpleado);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ServiceResult EliminarEmpleado(tbEmpleados tbEmpleados)
        {
            var result = new ServiceResult();
            try
            {
                var map = _empleadosRepository.Delete(tbEmpleados);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion


        #region Solicitud
        public ServiceResult ListadoSolicitud()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitudRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {

                return result.Error(e.Message);

            }
        }


        public VW_tbSolicitud_View BuscarSoliciud(int? id)
        {
            try
            {
                var list = _solicitudRepository.Find(id);
                return list;
            }
            catch (Exception)
            {

                return null;

            }
        }

        public ServiceResult InsertarSolicitud(tbSolicitud solicitud)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitudRepository.Insert(solicitud);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResult EditarSolicitud(tbSolicitud solicitud)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitudRepository.Update(solicitud);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ServiceResult EliminarSolicitud(tbSolicitud solicitud)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitudRepository.Delete(solicitud);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public ServiceResult Rezachar(tbRechazados rechazados)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitudRepository.Reject(rechazados);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }


        public ServiceResult Aceptar(tbAprobados aprobados)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitudRepository.Accept(aprobados);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion








        public IEnumerable<tbCargos> ListadoCargos()
        {

            try
            {
                var list = _empleadosRepository.ListCargos();
                return list;
            }
            catch (Exception )
            {

                return null;

            }
        }
        public IEnumerable<tbSucursales> ListadoSucursales()
        {

            try
            {
                var list = _empleadosRepository.ListSucursales();
                return list;
            }
            catch (Exception )
            {

                return null;

            }
        }
        public IEnumerable<tbEstadosCiviles> ListadoEstadosCiviles()
        {

            try
            {
                var list = _empleadosRepository.ListEstadosCiviles();
                return list;
            }
            catch (Exception )
            {

                return null;

            }
        }



        #region Solicitantes
        public ServiceResult ListadoSolicitantes()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitanteRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {

                return result.Error(e.Message);

            }
        }


        public VW_tbSolicitantes_View BuscarSolicitante(int? id)
        {
            try
            {
                var list = _solicitanteRepository.Find(id);
                return list;
            }
            catch (Exception)
            {

                return null;

            }
        }

        public ServiceResult InsertarSolicitante(tbSolicitantes solicitantes)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitanteRepository.Insert(solicitantes);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public ServiceResult EditarSolicitantes(tbSolicitantes solicitantes)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitanteRepository.Update(solicitantes);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ServiceResult EliminarSolicitantes(tbSolicitantes solicitantes)
        {
            var result = new ServiceResult();
            try
            {
                var map = _solicitanteRepository.Delete(solicitantes);
                if (map.CodeStatus > 0)
                {
                    return result.Ok(map);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.Error(map);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion



        #region DROP DOWN LIST

        //departamentos
        public ServiceResult DepartamentosDropDownList()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitanteRepository.DepartamentosDropDownList();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }


        //municipios
        public ServiceResult MunicipiosDropDownList(int id)
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitanteRepository.MunicipiosDropDownList(id);
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }

        public ServiceResult TipoLocenciDropDownList()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitudRepository.TipoLicenciaDropDownList();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }
        public ServiceResult SolicitanteDropDownList()
        {
            var result = new ServiceResult();
            try
            {
                var list = _solicitudRepository.SolicitanteDropDownList();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }

        #endregion

    }
}
