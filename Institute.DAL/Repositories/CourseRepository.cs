

using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<StudentRepository> logger;

        public CourseRepository(InstituteContext context, ILogger<StudentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exist(int courseId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            return context.Courses.OrderByDescending(st => st.CreationDate);
        }

        public Course GetCourse(int Id)
        {
            return context.Courses.Find(Id);
        }

        public void Remove(Course course)
        {
            context.Courses.Remove(course);
        }

        public void Save(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
        }

        public void Update(Course course)
        {
            try
            {
                Course courseToModify = GetCourse(course.Id);

                courseToModify.Title = course.Title;
                courseToModify.Credits = course.Credits;
                courseToModify.Department = course.Department;

                context.Courses.Update(courseToModify);

                context.SaveChanges();
            }
            catch (Exception err)
            {

                this.logger.LogError($"Error: {err.Message}", err.ToString());
            }

        }
    }
}
