using AutoMapper;
using ComitivaEsperanca.API.Data.Context;
using ComitivaEsperanca.API.Data.UnitOfWork;
using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.Repositories.Entities;
using ComitivaEsperanca.API.Domain.Interfaces.UnitOfWork;
using ComitivaEsperanca.API.Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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
            catch (Exception ex)
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

        public ResponseDTO<List<string>> GetNewsSources()
        {
            try
            {
                var news = _unitOfWork.NewsRepository.GetAll().Select(x => x.Source).Distinct().ToList();
                if (news == null)
                    return new ResponseDTO<List<string>>(StatusCodes.Status404NotFound);

                return new ResponseDTO<List<string>>(StatusCodes.Status200OK, news);
            }
            catch (Exception ex)
            {
                return new ResponseDTO<List<string>>(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public PaginatedItemsDTO<NewsDTO> GetList(string? search, string? sentiment, DateTime? date, string? source, int pageSize, int pageIndex)
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

            var itemsOnPage = GenericSort.SkipTakeAndSelectItemsAsync(newsList, pageSize, pageIndex, news => new NewsDTO(news)).Result;
            var totalItems = newsList.Count();

            return new PaginatedItemsDTO<NewsDTO>(pageIndex, pageSize, totalItems, itemsOnPage);
        }

        public ResponseDTO<List<NewsSentimentDTO>> GetDailySentiments()
        {
            var news = _unitOfWork.NewsRepository.GetAll()
                                                .Where(x => x.PublicationDate.Date.Equals(DateTime.UtcNow.Date.AddDays(-1)))
                                                .GroupBy(x => x.FinalSentiment)
                                                    .Select(x => new NewsSentimentDTO { Sentiment = x.Key, Count = x.Count() })
                                                                                                                        .ToList();

            return new ResponseDTO<List<NewsSentimentDTO>>(StatusCodes.Status200OK, news);
        }

        public string GetMostFrequentSentimentOnWeek()
        {
            DateTime endDate = DateTime.UtcNow.Date;
            DateTime startDate = endDate.AddDays(-6);
            startDate = startDate.Date.ToUniversalTime();
            DateTime date = DateTime.UtcNow.Date;

            int positiveCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Positiva");
            int neutralCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Neutra");
            int negativeCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Negativa");

            string mostFrequentSentiment = "Positiva";
            int mostFrequentSentimentCount = positiveCount;

            if (neutralCount > mostFrequentSentimentCount)
            {
                mostFrequentSentiment = "Neutra";
                mostFrequentSentimentCount = neutralCount;
            }
            if (negativeCount > mostFrequentSentimentCount)
            {
                mostFrequentSentiment = "Negativa";
                mostFrequentSentimentCount = negativeCount;
            }
            return mostFrequentSentiment;
        }

        public List<DailyReportDTO> GetDailyReport()
        {
            List<DailyReportDTO> dailyReports = new List<DailyReportDTO>();
            DateTime endDate = DateTime.UtcNow.Date;
            DateTime startDate = endDate.AddDays(-6);
            startDate = startDate.Date.ToUniversalTime();
            DateTime date = DateTime.UtcNow.Date;

            for (date = startDate; date <= endDate; date = date.AddDays(1))
            {
                int positiveCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Positiva");
                int neutralCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Neutra");
                int negativeCount = _unitOfWork.NewsRepository.GetAll().Count(n => n.PublicationDate.Date.ToUniversalTime() == date && n.FinalSentiment == "Negativa");

                DailyReportDTO dailyReport = new DailyReportDTO
                {
                    Date = date,
                    PositiveCount = positiveCount,
                    NeutralCount = neutralCount,
                    NegativeCount = negativeCount,
                    Sentiment = $"{positiveCount} positive, {neutralCount} neutral, {negativeCount} negative"
                };

                dailyReports.Add(dailyReport);
            }

            return dailyReports;
        }
    }
}
