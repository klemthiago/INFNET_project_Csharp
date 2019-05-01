using ProjetoINFNET.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Interfaces.Repositories
{
    public interface IRepositoryPerfilUsuario : IRepositoryBase<PerfilUsuario>
    {
        List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario);
        PerfilUsuario CadastraPerfilUsuario(PerfilUsuario perfil);
    }
}
