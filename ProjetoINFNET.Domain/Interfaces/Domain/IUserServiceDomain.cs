using ProjetoINFNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Interfaces.Domain
{
    public interface IUserServiceDomain
    {
        Usuario LogaUsuario(string email, string senha);
        Usuario RecuperarUsuarioPorEmail(string email);
        List<Usuario> RecuperaUsuariosDoPerfil(int IdPerfilUsuario); 
    }
}
