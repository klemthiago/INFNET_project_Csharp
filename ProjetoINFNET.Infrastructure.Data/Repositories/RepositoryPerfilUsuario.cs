using ProjetoINFNET.Domain.Entities;
using ProjetoINFNET.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Infrastructure.Data.Repositories
{
    public class RepositoryPerfilUsuario : RepositoryBase<PerfilUsuario>, IRepositoryPerfilUsuario
    {
        public List<Usuario> RetornaUsuariosDoPerfil(int idPerfilUsuario)
        {
            var perfil = _contexto.PerfilUsuario.Where(x => x.IdPerfilUsuario == idPerfilUsuario).FirstOrDefault();
            return perfil.Usuarios.ToList();
        }

        public PerfilUsuario CadastraPerfilUsuario(PerfilUsuario perfil)
        {
            return _contexto.PerfilUsuario.Add(perfil);
        }
    }
}
