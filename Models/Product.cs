using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [MinLength(5,ErrorMessage ="Title must be more than 5 letters")]
        [Required(ErrorMessage ="Title is Required")]
        [DisplayName("Product Title")]
        
        public string Title { get; set; }
        [Range(10,2000,ErrorMessage ="Price must be between 10 and 2000")]
        [DisplayName("Product Price")]
        [Required(ErrorMessage = "Price is required")]

        public decimal Price { get; set; }
        
        [DisplayName("Product Description")]
        public string Description { get; set; }
        [Range(1,100)]
        [DisplayName("Product Quantity")]
        [Required(ErrorMessage = "Description is required")]
        public int Quantity { get; set; }
        [RegularExpression(@"~/Images/.+\.(jpg|png)")]
        [DisplayName("Product Image Path")]
        [Required(ErrorMessage ="Image path is required")]
        public string ImagePath { get; set; }
        [DisplayName("Product Category")]
        [Required(ErrorMessage = "Product category is required")]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
