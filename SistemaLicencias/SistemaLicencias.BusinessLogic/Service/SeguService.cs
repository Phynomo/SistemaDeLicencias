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
        private readonly PantallasPorRolRepository _pantallasPorRolRepository;

        public SeguService(UsuarioRepository usuarioRepository,
                            RolesRepository rolesRepository,
                            PantallasRepository pantallasRepository,
                            PantallasPorRolRepository pantallasPorRolRepository
            )
        {
            _usuarioRepository = usuarioRepository;
            _rolesRepository = rolesRepository;
            _pantallasRepository = pantallasRepository;
            _pantallasPorRolRepository = pantallasPorRolRepository;
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
        
        public ServiceResult AccesoAPantallas(int? esAdmin, int? role_Id, int? pant_Id)
        {
            var result = new ServiceResult();
            try
            {
                var map = _usuarioRepository.AccesoAPantalla(esAdmin,role_Id,pant_Id);
                if (map.CodeStatus == 1)
                {
                    return result.SetMessage(map.CodeStatus.ToString(), ServiceResultType.Success);
                }
                else if (map.CodeStatus == 0)
                {
                    return result.SetMessage(map.CodeStatus.ToString(), ServiceResultType.Conflict);
                }
                else
                {
                    return result.SetMessage("0", ServiceResultType.Error);
                }
            }
            catch (Exception e)
            {
                return result.SetMessage("0", ServiceResultType.Error);
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
                if (map.CodeStatus > 0)
                {
                    return result.SetMessage( map.CodeStatus.ToString() , ServiceResultType.Success);
                }
                else if (map.CodeStatus == -2)
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
                else if (map.CodeStatus == -1)
                {
                    return result.SetMessage("Rol en uso", ServiceResultType.Conflict);
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


        #region Pantallas por Roles

        public ServiceResult InsertarPantallasPorRol(tbPantallasPorRoles pantxrol)
        {
            var result = new ServiceResult();
            try
            {
                var map = _pantallasPorRolRepository.Insert(pantxrol);
                if (map.CodeStatus > 0)
                {
                    return result.SetMessage(map.CodeStatus.ToString(), ServiceResultType.Success);
                }
                else if (map.CodeStatus == -2)
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


        public ServiceResult EliminarPantallasXRol(tbPantallasPorRoles pant)
        {
            var result = new ServiceResult();
            try
            {
                var map = _pantallasPorRolRepository.Delete(pant);
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


        public IEnumerable<VW_tbPantallasPorRoles_View> ListadoPxRxR(int? rol_Id)
        {
            try
            {
                var list = _pantallasPorRolRepository.ListPxRxR(rol_Id);
                return list;
            }
            catch (Exception )
            {
                return null;
            }
        }

        #endregion

    }
}
