using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IList<TEntity> RecuperarTodos();
        TEntity RecuperarPorID(int id);
        void Inserir(TEntity obj);
        void Alterar(TEntity obj);
        void Remover(TEntity obj);
        void Remover(int id);
    }
}
