using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Entities.Models
{
    public class Book
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime PublishDateUtc { get; set; }
    }
}
