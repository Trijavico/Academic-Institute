

using Institute.DAL.Entities;

namespace Institute.DAL.Interfaces
{
    public interface IStudentGradeRepository
    {
        void Save(StudentGrade studentGrade);
        void Update(StudentGrade studentGrade);
        void Remove(StudentGrade studentGrade);
        StudentGrade GetStudentGrade(int studentGrade);
        IEnumerable<StudentGrade> GetAll();
        bool Exists(int studentGrade);
    }
}
