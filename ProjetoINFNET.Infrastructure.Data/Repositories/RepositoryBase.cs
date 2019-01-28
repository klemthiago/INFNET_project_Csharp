using CommonServiceLocator;
using ProjetoINFNET.Domain.Interfaces.Infrastructure;
using ProjetoINFNET.Domain.Interfaces.Repositories;
using ProjetoINFNET.Infrastructure.Data.Configuration;
using ProjetoINFNET.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ProjetoINFNET.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ContextoBanco _contexto;
        public RepositoryBase()
        {
            var gerenciador = (RepositoryManager)ServiceLocator.Current.GetInstance<IRepositoryManager>();
            _contexto = gerenciador.Contexto;
        }
        public void Alterar(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Inserir(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
        }

        public TEntity RecuperarPorID(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public IList<TEntity> RecuperarTodos()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public void Remover(TEntity obj)
        {
            _contexto.Set<TEntity>().Remove(obj);
        }

        public void Remover(int id)
        {
            TEntity obj = RecuperarPorID(id);
            _contexto.Set<TEntity>().Remove(obj);
        }
    }
}
