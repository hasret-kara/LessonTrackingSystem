using LessonTrackingSystem.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace LessonTrackingSystem.DataAccess.DbContex
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}