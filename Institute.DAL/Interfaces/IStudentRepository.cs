using Institute.DAL.Entities;

namespace Institute.DAL.Interfaces
{
    public interface IStudentRepository
    {
        void Save(Student student);
        void Update(Student student);
        void Remove(Student student);
        Student GetStudent(int studentId);
        IEnumerable<Student> GetAll();
        bool Exists(int studentId);
    }
}
