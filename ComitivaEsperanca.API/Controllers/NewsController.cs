﻿using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ComitivaEsperanca.API.Controllers
{
    [Route("news/")]
    [ApiController]
    public class NewsController : Controller
    {
        private readonly NewsService _newsService;

        public NewsController(NewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseDTO<NewsDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<NewsDTO>))]
        public IActionResult Create([FromBody] NewsDTO newsDTO)
        {
            var response = _newsService.CreateNews(newsDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<NewsDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<NewsDTO>))]
        public IActionResult Update([FromBody] NewsDTO newsDTO)
        {
            var response = _newsService.UpdateNews(newsDTO);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<NewsDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<NewsDTO>))]
        public IActionResult GetById(Guid id)
        {
            var response = _newsService.GetNewsById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("/count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetTotalNews()
        {
            var response = _newsService.GetTotalNews();
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("Paginated")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<List<NewsDTO>>))]
        public PaginatedItemsDTO<NewsDTO> GetPaginated(
            [FromQuery] string? search,
            [FromQuery] string? sentiment,
            [FromQuery] DateTime? date,
            [FromQuery] string? source,
            [FromQuery] int pageSize = 10,
            [FromQuery] int pageIndex = 1)
        {
            return _newsService.GetList(search, sentiment, date, source, pageSize, pageIndex);
        }

        [HttpGet("Sources")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<List<string>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<List<string>>))]
        public IActionResult GetNewsSources()
        {
            var response = _newsService.GetNewsSources();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("DailySentiments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<List<NewsSentimentDTO>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<List<NewsSentimentDTO>>))]
        public IActionResult GetDailySentiments()
        {
            var response = _newsService.GetDailySentiments();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("WeeklySentiments")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<List<NewsSentimentDTO>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<List<NewsSentimentDTO>>))]
        public List<DailyReportDTO> GetWeeklySentiments()
        {
            return _newsService.GetDailyReport();
        }

        [HttpGet("MostFrequentSentimentOnWeek")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public string GetMostFrequentSentimentOnWeek()
        {
            return _newsService.GetMostFrequentSentimentOnWeek();
        }

        [HttpPost("SaveSuggestedSentiment")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseDTO<ClassifiedNews>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<ClassifiedNews>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseDTO<ClassifiedNews>))]
        public IActionResult Create(Guid newsId, string sentiment)
        {
            var response = _newsService.SaveSuggestedFeeling(newsId, sentiment);
            return StatusCode(response.StatusCode, response.Entity);
        }


    }
}
