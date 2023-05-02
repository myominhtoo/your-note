using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNote.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Unicode(true)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Username { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; } = null;

        public ICollection<Category>? Categories { get; set; } = null;

    }
}
