using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.Repositories.Entities;

namespace ComitivaEsperanca.API.Data.Repositories.Entities
{
    public class NewsRepository : BaseRepository<News>, INewsRepository
    {
        public NewsRepository(CoreContext context) : base(context)
        {

        }
    }
}
