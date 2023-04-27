using ComitivaEsperanca.API.Domain.DTOs;
using ComitivaEsperanca.API.Domain.Entities;
using ComitivaEsperanca.API.Service.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseDTO<NewsDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseDTO<NewsDTO>))]
        public IActionResult GetById(Guid id)
        {
            var response = _newsService.GetNewsById(id);
            return StatusCode(response.StatusCode, response);

        }
        
                                  
    }
}
