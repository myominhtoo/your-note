using System.ComponentModel.DataAnnotations;

namespace DailyNote.Models.Entities
{
    public class Note
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsImportant { get; set; } = false;

        public string? BookmarkColor { get; set; } = null;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; } = null;


        public Category Category { get; set; }

    }
}
