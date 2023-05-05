using ComitivaEsperanca.API.Domain.Interfaces.Repositories.Entities;

namespace ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        INewsRepository NewsRepository { get;}
        int Commit();
        dynamic GetContext();
    }
}
