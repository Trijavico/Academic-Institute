using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<DepartmentRepository> logger;
        public DepartmentRepository(InstituteContext context, ILogger<DepartmentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public bool Exist(int departmentId)
        {
            return context.Departments.Any(cd => cd.Id == departmentId);
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.OrderByDescending(st => st.CreationDate);
        }

        public Department GetDepartment(int departmentId)
        {
            return context.Departments.Find(departmentId);
        }
        public void Remove(Department department)
        {
            context.Departments.Remove(department);
        }
        public void Save(Department department)
        {
            context.Departments.Add(department);
            context.SaveChanges();
        }
        public void Update(Department department)
        {
            try
            {
                Department departmentToModify = GetDepartment(department.Id);

                departmentToModify.Name = department.Name;
                departmentToModify.Administrator = department.Administrator;
                departmentToModify.Budget = department.Budget;
                
                context.Departments.Update(departmentToModify);

                context.SaveChanges();
            }
            catch (Exception err)
            {

                this.logger.LogError($"Error: {err.Message}", err.ToString());
            }
        }
    }
}
