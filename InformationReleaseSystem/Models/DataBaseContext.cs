using Microsoft.EntityFrameworkCore;

namespace InformationReleaseSystem.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Sort> Sorts { get; set; }
        public DbSet<Text> Texts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
