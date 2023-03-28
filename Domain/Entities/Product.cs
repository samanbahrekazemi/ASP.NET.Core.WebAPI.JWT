using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.Zero;


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
