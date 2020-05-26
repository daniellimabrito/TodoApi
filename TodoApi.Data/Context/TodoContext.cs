using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Mappings;
using TodoApi.Domain;

namespace TodoApi.Data.Context
{
    public class TodoContext : DbContext
    {
        public  DbSet<ToDoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server= (localdb)\\mssqllocaldb; Database = TodoData; Trusted_Connection = True; ");
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
