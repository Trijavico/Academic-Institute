
using Microsoft.EntityFrameworkCore;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;

namespace Institute.DAL.Context
{
    public partial class InstituteContext : DbContext
    {
        public InstituteContext()
        {

        }

        public InstituteContext(DbContextOptions<InstituteContext> options)   
            : base(options)
        {

        }

        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
    }
}
