using dotnetPartTwo.Api.Helpers;
using dotnetPartTwo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetPartTwo.Api.Data
{    
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses {get;set;}
        public DbSet<Student> Students {get;set;}
        public DbSet<StudentCourse> StudentCourses {get;set;}

        public SchoolContext()
        {
            
        }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var contextRoot = DirectoryHelpers.GetApplicationRoot();
            optionsBuilder.UseSqlite($"Data Source={contextRoot}School.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: the 'Seed' method is used to populate the database with data
            // in order to utilize this method, you'll need to add a migration
            // and then update the database

            //modelBuilder.Seed();
        }
    }
}