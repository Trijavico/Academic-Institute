

using Institute.DAL.Entities.Production;

namespace Institute.DAL.Interfaces
{
    public interface IDepartmentRepository
    {
        void Save(Department department);
        void Update(Department department);
        void Remove(Department department);
        Department GetDepartment(int departmentId);
        IEnumerable<Department> GetAll();
        bool Exist(int departmentId);
    }
}
