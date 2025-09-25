using Microsoft.EntityFrameworkCore;

namespace VkApiSPA.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Token> Users { get; set; } 
        public DbSet<Group> Departments { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
