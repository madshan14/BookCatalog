using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Entities.Models
{
    public class Category
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
