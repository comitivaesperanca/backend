using AutoMapper;
using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Data.UnitOfWork;
using ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork;

namespace ComitivaEsperanca.API.Service.Services
{
    public class NewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewsService(CoreContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }
    }
}
