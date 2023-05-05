using ComitivaEsperanca.API.Domain.Entities;

namespace ComitivaEsperanca.API.Domain.DTOs
{
    public class NewsDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CommodityType { get; set; }
        public string Source { get; set; }
        public double PositiveSentiment { get; set; }
        public double NeutralSentiment { get; set; }
        public double NegativeSentiment { get; set; }
        public string FinalSentiment { get; set; }

        public NewsDTO()
        {
            
        }
        public NewsDTO(News news)
        {
            Id = news.Id;
            Title = news.Title;
            NewsContent = news.NewsContent;
            PublicationDate = news.PublicationDate;
            CommodityType = news.CommodityType;
            Source = news.Source;
            PositiveSentiment = news.PositiveSentiment;
            NeutralSentiment = news.NeutralSentiment;
            NegativeSentiment = news.NegativeSentiment;
            FinalSentiment = news.FinalSentiment;
        }
    }
}
