using SistemaLicencias.DataAccess.Repository;
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
        private readonly SolicitanteRepository _solicitanteRepository;

        public LicenciaServivce(TipoLicenciaRepository tipoLicenciaRepository,
                                SolicitanteRepository solicitanteRepository)
        {
            _tipoLicenciaRepository = tipoLicenciaRepository;
            _solicitanteRepository = solicitanteRepository;
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

        #endregion

    }
}
