using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyNote.Models.Entities
{
    [Table(name:"Categories")]
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public UserEntity? User { get; set; } = null;

        public List<NoteEntity> Notes { get; set; }

    }
}
