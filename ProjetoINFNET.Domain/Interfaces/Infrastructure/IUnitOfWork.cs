using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoINFNET.Domain.Interfaces.Infrastructure
{
    public interface IUnitOfWork
    {
        void Iniciar();
        void Persistir();
    }
}
