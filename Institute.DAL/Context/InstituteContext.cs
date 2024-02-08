
using Microsoft.EntityFrameworkCore;
using Institute.DAL.Entities;

namespace Institute.DAL.Context
{
    public class InstituteContext : DbContext
    {

        public InstituteContext(DbContextOptions<InstituteContext> options)   
            : base(options)
        {

        }

        public DbSet<Professor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region tables
            modelBuilder.Entity<Professor>().ToTable("Professor");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Course>().ToTable("Course");
            #endregion

            #region primary keys
            modelBuilder.Entity<Professor>().HasKey(entity => entity.Id);
            modelBuilder.Entity<Professor>().HasKey(entity => entity.Id);
            modelBuilder.Entity<Professor>().HasKey(entity => entity.Id);
            #endregion

            #region relationships
            modelBuilder.Entity<Course>().HasMany<Student>(course => course.Students);
            modelBuilder.Entity<Student>().HasMany<Course>(student => student.Courses);
            #endregion

            #region property configuration
            modelBuilder.Entity<Student>()
                .Property(student => student.EnrollmentDate)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(student => student.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(student => student.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Professor>()
                .Property(professor => professor.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Professor>()
                .Property(professor => professor.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Professor>()
                .Property(professor => professor.HireDate)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(course => course.Title)
                .IsRequired()
                .HasMaxLength(100);
            #endregion
        }
    }
}
