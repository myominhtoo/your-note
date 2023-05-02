using DailyNote.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DailyNote.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options ) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
