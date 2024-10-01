using Microsoft.EntityFrameworkCore;

namespace crudApi.Models
{
    public class PostgreSqlDbContext : DbContext
    {
        public PostgreSqlDbContext(DbContextOptions option) : base(option) { }

        public DbSet<Student> Students { get; set; }
    }
}
