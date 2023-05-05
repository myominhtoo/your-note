using System.ComponentModel.DataAnnotations;

namespace DailyNote.Models.ViewModels.Request
{
    public class UpdateUserRequestViewModel
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Username is required!")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 20 characters!")]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 15 characters!")]
        public string Password { get; set; }
    }
}
