using System.ComponentModel.DataAnnotations;

namespace DailyNote.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public User? User { get; set; } = null;

        public List<Note> Notes { get; set; }

    }
}
