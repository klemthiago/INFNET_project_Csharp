using ProjetoINFNET.Domain.Entities;
using System.Collections.Generic;

namespace ProjetoINFNET.Domain.Interfaces.Domain
{
    public interface IUserServiceDomain
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperarUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int IdPerfilUsuario);
        List<PerfilUsuario> RecuperaTodosPerfisAtivos();
        void CadastraUsuario(Usuario usuario);
    }
}
