using ProjetoDDD.Infrastructure.Data.Security;
using ProjetoINFNET.Domain.Entities;
using ProjetoINFNET.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Infrastructure.Data.Repositories
{
    public class RepositoryUsuarios : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        public Usuario CadastraUsuario(Usuario user)
        {
            user.Senha = Crypto.EncryptStringAES(user.Senha, user.SenhaKey);
            return _contexto.Usuarios.Add(user);
        }

        public Usuario LogaUsuario(string email, string senha)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            if (usuario == null)
                return null;

            string passDecrypt = Crypto.DecryptStringAES(usuario.Senha, usuario.SenhaKey);

            if (passDecrypt == senha)
                return usuario;
            else return null;
        }

        public Usuario RecuperarUsuarioPorEmail(string email)
        {
            var usuario = _contexto.Usuarios.Where(u => u.Email == email).FirstOrDefault();
            return usuario;
        }
    }
}
