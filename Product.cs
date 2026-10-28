using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Category { get; set; }

        [Range(0, 1000000)]
        public int Quantity { get; set; }

        [Range(typeof(decimal), "0.01", "9999999.99")]
        public decimal Price { get; set; }
    }
}
