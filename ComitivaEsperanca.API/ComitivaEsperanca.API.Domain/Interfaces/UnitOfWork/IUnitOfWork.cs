using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {

        int Commit();
        dynamic GetContext();
    }
}
