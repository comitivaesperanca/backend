namespace ComitivaEsperanca.API.Domain.DTOs
{
    public class DailyReportDTO
    {
        public DateTime Date { get; set; }
        public int PositiveCount { get; set; }
        public int NeutralCount { get; set; }
        public int NegativeCount { get; set; }
        public string Sentiment { get; set; }
    }
}
