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

        #endregion


    }
}
