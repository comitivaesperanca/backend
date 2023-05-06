using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComitivaEsperanca.API.Domain.Entities
{
    public class ClassifiedNews
    {
        [Key]
        public Guid Id { get; set; }
        public Guid NewsId { get; set; }
        public string SuggestedFeeling { get; set; }

        #region [Foreign Key]
        [ForeignKey("NewsId")]
        public News News { get; set; }
        #endregion
    }
}
