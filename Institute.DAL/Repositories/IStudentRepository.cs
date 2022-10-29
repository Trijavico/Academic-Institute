
using Institute.DAL.Entities;
using System.Xml.Linq;

namespace Institute.DAL.Repositories
{
    public interface IStudentRepository
    {
        void Save(Student student);
        void Update(Student student);
        void Remove(Student student);
        Student GetStudent(int studentId);

        bool Exists(int studentId);
    }
}
