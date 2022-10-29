

using Institute.DAL.Entities;

namespace Institute.DAL.Interfaces
{
    public interface ICourseRepository
    {
        void Save(Course course);
        void Update(Course course);
        void Remove(Course course);
        Course GetCourse(int CourseId);
        IEnumerable<Course> GetAll();
        bool Exist(int courseId);
    }
}
