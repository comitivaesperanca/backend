using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.Repositories.Entities;

namespace ComitivaEsperanca.API.Data.Repositories.Entities
{
    public class ClassifiedNewsRepository : BaseRepository<ClassifiedNews>, IClassifiedNewsRepository
    {
        public ClassifiedNewsRepository(CoreContext context) : base(context)
        {

        }
    }
}
