using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Data.Entities.Product
{
    public class Product : BaseEntity<int>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }

        public virtual List<Photo> Photos { get; set; }


    }
}
