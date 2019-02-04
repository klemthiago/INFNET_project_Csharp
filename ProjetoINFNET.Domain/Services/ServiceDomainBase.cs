using Microsoft.Practices.ServiceLocation;
using ProjetoINFNET.Domain.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Services
{
    public class ServiceDomainBase
    {
        private IUnitOfWork _unitOfWork;
        public virtual void IniciarTransacao()
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _unitOfWork.Iniciar();
        }
        public virtual void PersistirTransacao()
        {
            _unitOfWork.Persistir();
        }
    }
}
