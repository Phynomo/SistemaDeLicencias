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

        public LicenciaServivce(TipoLicenciaRepository tipoLicenciaRepository)
        {
            _tipoLicenciaRepository = tipoLicenciaRepository;
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

    }
}
