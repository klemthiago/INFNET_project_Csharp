using Microsoft.Practices.ServiceLocation;
using ProjetoINFNET.Domain.Interfaces.Infrastructure;
using ProjetoINFNET.Infrastructure.Data.Context;

namespace ProjetoINFNET.Infrastructure.Data.Configuration
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private ContextoBanco _contexto;
        public void Iniciar()
        {
            var gerenciador = ServiceLocator.Current.GetInstance<IRepositoryManager>()
                as RepositoryManager;
            _contexto = gerenciador.Contexto;
        }

        public void Persistir()
        {
            _contexto.SaveChanges();
        }
    }
}
