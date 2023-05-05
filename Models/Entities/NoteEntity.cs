using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNote.Models.Entities
{
    [Table(name:"Notes")]
    public class NoteEntity
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


        public CategoryEntity Category { get; set; }

    }
}
