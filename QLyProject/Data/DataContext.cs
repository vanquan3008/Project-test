
using Microsoft.EntityFrameworkCore;
using QLyProject.Models;

namespace QLyProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
    }
}
