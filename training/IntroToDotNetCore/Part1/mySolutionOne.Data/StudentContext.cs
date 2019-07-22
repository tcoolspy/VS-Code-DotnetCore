using Microsoft.EntityFrameworkCore;
using mySolutionOne.Core.Models;

namespace mySolutionOne.Api.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students {get;set;}

        public StudentContext() {}

        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=students.db");
            }            
        }
    }
}