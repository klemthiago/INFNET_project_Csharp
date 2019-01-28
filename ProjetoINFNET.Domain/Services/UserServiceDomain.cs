using ProjetoINFNET.Domain.Entities;
using ProjetoINFNET.Domain.Interfaces.Domain;
using ProjetoINFNET.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;

namespace ProjetoINFNET.Domain.Services
{
    public class UserServiceDomain : IUserServiceDomain
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPerfilUsuario _repositoryPerfil;
        public UserServiceDomain(IRepositoryUsuario repositoryUsuario, IRepositoryPerfilUsuario repositoryPerfil)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryPerfil = repositoryPerfil;
        }
        public Usuario LogaUsuario(string email, string senha)
        {
            //regras de negocio aqui
            var usuarioRetorno = _repositoryUsuario.LogaUsuario(email, senha);
            return usuarioRetorno;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuarioRetorno = _repositoryUsuario.RecuperarUsuarioPorEmail(email);
            return usuarioRetorno;
        }

        public List<Usuario> RecuperaUsuariosDoPerfil(int IdPerfilUsuario)
        {
            var usuariosDoPerfil = _repositoryPerfil.RetornaUsuariosDoPerfil(IdPerfilUsuario);
            return usuariosDoPerfil;
        }
    }
}
