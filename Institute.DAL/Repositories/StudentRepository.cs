using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly InstituteContext context;
        private readonly ILogger<StudentRepository> logger;
        public StudentRepository(InstituteContext context, ILogger<StudentRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(int studentId)
        {
            return this.context.Students.Any(cd => cd.Id == studentId);
        }

        public IEnumerable<Student> GetAll()
        {
            return context.Students.OrderByDescending(st => st.CreationDate);
        }

        public Student GetStudent(int studentId)
        {
            return this.context.Students.Find(studentId);
        }

        public void Remove(Student student)
        {
            context.Students.Remove(student);
        }

        public void Save(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        public void Update(Student student)
        {
            try
            {
                Student studentToModify = GetStudent(student.Id);

                studentToModify.FirstName = student.FirstName;
                studentToModify.LastName = student.LastName;
                studentToModify.ModifyDate = student.ModifyDate;
                studentToModify.UserMod = student.UserMod;
                studentToModify.EnrollmentDate = student.EnrollmentDate;
                studentToModify.Id = student.Id;

                context.Students.Update(studentToModify);

                context.SaveChanges();
            }
            catch (Exception err)
            {

                this.logger.LogError($"Error: {err.Message}", err.ToString());
            }
        }
    }
}
