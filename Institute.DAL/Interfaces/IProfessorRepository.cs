using Institute.DAL.Entities.Production;

namespace Institute.DAL.Interfaces
{
    public interface IProfessorRepository
    {
        void Save(Professor student);
        void Update(Professor student);
        void Remove(Professor student);
        Professor GetProfessor(int studentId);
        IEnumerable<Professor> GetAll();
        bool Exists(int studentId);
    }
}
