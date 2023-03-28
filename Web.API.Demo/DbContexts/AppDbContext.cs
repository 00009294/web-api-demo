using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Web.API.Demo.Models;

namespace Web.API.Demo.DbContexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }       
        public DbSet<Student> Students { get; set; } = default!;
        public DbSet<Subject> Subjects { get; set; } = default!;
        public DbSet<Teacher> Teachers { get; set; } = default!;
        public DbSet<StudentSubject> StudentSubjects { get; set; } = default!;
        public DbSet<StudentTeacher> StudentTeachers { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasOne<Subject>(t => t.Subject)
                .WithMany(s => s.Teachers)
                .HasForeignKey(t => t.SubjectId);

            modelBuilder.Entity<StudentSubject>()
                .HasKey(ss => new { ss.StudentId, ss.SubjectId });
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Student)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(ss => ss.StudentId);
            modelBuilder.Entity<StudentSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(ss => ss.StudentSubjects)
                .HasForeignKey(ss => ss.SubjectId);
           

            modelBuilder.Entity<StudentTeacher>()
                .HasKey(st => new { st.StudentId, st.TeacherId });
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Student)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.StudentId);
            modelBuilder.Entity<StudentTeacher>()
                .HasOne(st => st.Teacher)
                .WithMany(st => st.StudentTeachers)
                .HasForeignKey(st => st.TeacherId);

           
        }
    }
}
