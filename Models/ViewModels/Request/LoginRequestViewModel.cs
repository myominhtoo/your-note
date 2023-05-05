using System.ComponentModel.DataAnnotations;

namespace DailyNote.Models.ViewModels.Request
{
    public class LoginRequestViewModel
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
