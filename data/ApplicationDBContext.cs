using DailyNote.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNote.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options ) : base(options)
        {
            
        }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<CategoryEntity> Category { get; set; }
    }
}
