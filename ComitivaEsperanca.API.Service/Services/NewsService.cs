using AutoMapper;
using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Data.UnitOfWork;
using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork;
using ComitivaEsperanca.API.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public ResponseDTO<News> UpdateNews(NewsDTO newsDTO)
        {
            #region [Validations]
            #endregion
            try
            {
                var news = _mapper.Map<News>(newsDTO);

                _unitOfWork.NewsRepository.Update(news);

                if (_unitOfWork.Commit() > 0)
                    return new ResponseDTO<News>(StatusCodes.Status200OK, news);

                return new ResponseDTO<News>(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<News>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }   

        public int GetTotalNews()
        {
            return _unitOfWork.NewsRepository.GetAll().Count();
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
        public async Task<PaginatedItemsDTO<NewsDTO>> GetListAsync(string? search, string? sentiment, DateTime? date, string? source, int pageSize, int pageIndex)
        {

            IQueryable<News> newsList = _unitOfWork.NewsRepository.GetAll().OrderBy(x => x.Title);

            if (search != null)
                newsList = newsList.Where(x => x.Title.Contains(search) || x.NewsContent.Contains(search));

            if (source != null)
                newsList = newsList.Where(x => x.Source.Equals(source));

            if (sentiment != null)
                newsList = newsList.Where(x => x.FinalSentiment.Equals("Positivo"));

            if (sentiment != null)
                newsList = newsList.Where(x => x.FinalSentiment.Equals("Neutro"));

            if (sentiment != null)
                newsList = newsList.Where(x => x.FinalSentiment.Equals("Negativo"));

            if (date != null)
                newsList = newsList.Where(x => x.PublicationDate.CompareTo(date) == 0);




            var itemsOnPage = await GenericSort.SkipTakeAndSelectItemsAsync(newsList, pageSize, pageIndex, news => new NewsDTO(news));
            var totalItems = await newsList.CountAsync();

            return new PaginatedItemsDTO<NewsDTO>(pageIndex, pageSize, totalItems, itemsOnPage);
        }
    }
}
