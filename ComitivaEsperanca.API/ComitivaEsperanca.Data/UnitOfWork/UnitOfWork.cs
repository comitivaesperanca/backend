using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork;

namespace ComitivaEsperanca.API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreContext _context;
        private bool disposed = false;

        public UnitOfWork(CoreContext context) 
        {
            _context = context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
                    _context.Dispose();
            
            this.disposed = true;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public dynamic GetContext()
        {
            return _context;
        }
    }
}
