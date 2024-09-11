using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace finalProject.Models
{
    public class User
    {
        public int UserId { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "First Name is Required.")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(12, MinimumLength = 3, ErrorMessage = "Name Must be between 3 and 12 character.")]
        [Required(ErrorMessage = "Last Name is Required.")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email is Required.")]
        [EmailAddress]
        [DisplayName("User Email")]
        public string Email { get; set; }
        [MinLength(6,ErrorMessage ="Password must be more than or equal 6 characters")]
        [Required(ErrorMessage = "Password is Required.")]
        public string Password { get; set; }

    }
}
