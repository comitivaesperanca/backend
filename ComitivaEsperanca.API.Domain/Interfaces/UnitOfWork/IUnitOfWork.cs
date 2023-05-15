using ComitivaEsperanca.API.Domain.Interfaces.Repositories.Entities;

namespace ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        INewsRepository NewsRepository { get;}
        IClassifiedNewsRepository ClassifiedNewsRepository { get;}
        int Commit();
        dynamic GetContext();
    }
}
