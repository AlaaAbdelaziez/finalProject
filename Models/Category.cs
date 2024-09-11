using System.ComponentModel.DataAnnotations;

namespace finalProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(5, ErrorMessage = "Title must be more than 5 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage = "Description must be more than 10 letters")]
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
