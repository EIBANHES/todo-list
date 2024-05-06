using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data
{
    // Precisa do dbcontext
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // sqlite
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }
    }

}
