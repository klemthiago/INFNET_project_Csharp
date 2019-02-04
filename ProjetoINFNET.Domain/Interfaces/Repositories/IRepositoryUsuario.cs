using ProjetoINFNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        Usuario RecuperarUsuarioPorEmail(string email);
        Usuario LogaUsuario(string email, string senha);
        Usuario CadastraUsuario(Usuario usuario);
    }
}
