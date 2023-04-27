using AutoMapper;
using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Data.UnitOfWork;
using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Http;

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

        public ResponseDTO<News> CreateNews(NewsDTO newsDTO)
        {
            #region [Validations]

            #endregion

            try
            {
                var news = _mapper.Map<News>(newsDTO);
                _unitOfWork.NewsRepository.Add(news);
             
                if (_unitOfWork.Commit() > 0)
                    return new ResponseDTO<News>(StatusCodes.Status201Created, news);

                return new ResponseDTO<News>(StatusCodes.Status400BadRequest);
            }
            catch(Exception ex)
            {
                return new ResponseDTO<News>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public ResponseDTO<News> GetNewsById(Guid id)
        {
            try
            {
                var news = _unitOfWork.NewsRepository.Get(x => x.Id == id);
                if (news == null)
                    return new ResponseDTO<News>(StatusCodes.Status404NotFound);
                return new ResponseDTO<News>(StatusCodes.Status200OK, news);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<News>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
