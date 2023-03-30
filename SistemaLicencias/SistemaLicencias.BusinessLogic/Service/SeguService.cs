using SistemaLicencias.DataAccess.Repository;
using SistemaLicencias.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.BusinessLogic.Service
{
    public class SeguService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public SeguService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #region Usuarios

        public VW_tbUsuarios_View Login(tbUsuarios item)
        {
            try
            {
                var list = _usuarioRepository.Login(item);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public ServiceResult Recuperar(tbUsuarios item)
        {

            var result = new ServiceResult();
            try
            {
                var map = _usuarioRepository.Recuperar(item);
                if (map.CodeStatus > 0)
                {
                    return result.SetMessage("Usuario Recuperado", ServiceResultType.Success);
                }
                else
                {
                    map.MessageStatus = (map.CodeStatus == 0) ? "404 Error de consulta" : map.MessageStatus;
                    return result.SetMessage("Recuperacion Fallida", ServiceResultType.Conflict);
                }
            }
            catch (Exception)
            {

                return null;

            }
        }


        public ServiceResult ListadoUsuarios()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }


        public VW_tbUsuarios_View BuscarUsuario(int? id)
        {
            try
            {
                var list = _usuarioRepository.Find(id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ServiceResult InsertarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuarioRepository.Insert(usuario);
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

        public ServiceResult EditarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuarioRepository.Update(usuario);
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


        public ServiceResult EliminarUsuario(tbUsuarios usuario)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuarioRepository.Delete(usuario);
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


        public ServiceResult RolDropDownList()
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.RolesDropDownList();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }




        public ServiceResult ListadoMenu(tbPantallas item)
        {
            var result = new ServiceResult();
            try
            {
                var list = _usuarioRepository.PantallasMenu(item);
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
