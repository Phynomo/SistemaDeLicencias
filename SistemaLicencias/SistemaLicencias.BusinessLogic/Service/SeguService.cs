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
        private readonly RolesRepository _rolesRepository;
        private readonly PantallasRepository _pantallasRepository;

        public SeguService(UsuarioRepository usuarioRepository,
                            RolesRepository rolesRepository,
                            PantallasRepository pantallasRepository
            )
        {
            _usuarioRepository = usuarioRepository;
            _rolesRepository = rolesRepository;
            _pantallasRepository = pantallasRepository;
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


        #endregion

        #region Roles

        public ServiceResult ListadoRoles()
        {
            var result = new ServiceResult();
            try
            {
                var list = _rolesRepository.List();
                return result.Ok(list);
            }
            catch (Exception e)
            {
                return result.Error(e.Message);
            }
        }

        public ServiceResult InsertarRoles(tbRoles roles)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rolesRepository.Insert(roles);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else if (map.CodeStatus == 2)
                {
                    return result.SetMessage("Registro repetido", ServiceResultType.Conflict);
                }
                else if (map.CodeStatus == 0)
                {
                    return result.SetMessage("Insert fallido", ServiceResultType.Error);
                }
                else
                {
                    return result.SetMessage("Error inesperado", ServiceResultType.Error);
                }
            }
            catch (Exception)
            {
                return result.SetMessage("Error inesperado", ServiceResultType.Error);
            }
        }

        public ServiceResult EditarRoles(tbRoles roles)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rolesRepository.Update(roles);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else if (map.CodeStatus == 2)
                {
                    return result.SetMessage("Registro repetido", ServiceResultType.Conflict);
                }
                else if (map.CodeStatus == 0)
                {
                    return result.SetMessage("Update fallido", ServiceResultType.Error);
                }
                else
                {
                    return result.SetMessage("Error inesperado", ServiceResultType.Error);
                }
            }
            catch (Exception)
            {
                return result.SetMessage("Error inesperado", ServiceResultType.Error);
            }
        }

        public ServiceResult EliminarRoles(tbRoles roles)
        {
            var result = new ServiceResult();
            try
            {
                var map = _rolesRepository.Delete(roles);
                if (map.CodeStatus == 1)
                {
                    return result.Ok(map);
                }
                else if (map.CodeStatus == 0)
                {
                    return result.SetMessage("Delete fallido", ServiceResultType.Error);
                }
                else
                {
                    return result.SetMessage("Error inesperado", ServiceResultType.Error);
                }
            }
            catch (Exception)
            {
                return result.SetMessage("Error inesperado", ServiceResultType.Error);
            }
        }

        public VW_tbRoles_View BuscarRoles(int? id)
        {
            try
            {
                var list = _rolesRepository.Find(id);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }


        #endregion


        #region Pantallas

        public ServiceResult ListadoPantallas()
        {
            var result = new ServiceResult();
            try
            {
                var list = _pantallasRepository.List();
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
