
using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class StudentGradeRepository : IStudentGradeRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<StudentGradeRepository> logger;
        public StudentGradeRepository(InstituteContext context, ILogger<StudentGradeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(int studentGradeId)
        {
            return this.context.StudentGrades.Any(cd => cd.Id == studentGradeId);
        }

        public IEnumerable<StudentGrade> GetAll()
        {
            return context.StudentGrades.OrderByDescending(st => st.Id);
        }

        public StudentGrade GetStudentGrade(int studentGradeId)
        {
            return context.StudentGrades.Find(studentGradeId);
        }

        public void Remove(StudentGrade studentGrade)
        {
            context.StudentGrades.Remove(studentGrade);
        }

        public void Save(StudentGrade studentGrade)
        {
            context.StudentGrades.Add(studentGrade);
            context.SaveChanges();
        }

        public void Update(StudentGrade studentGrade)
        {
            try
            {
                StudentGrade studentGradeToModify = GetStudentGrade(studentGrade.Id);

                studentGradeToModify.course = studentGrade.course;
                studentGradeToModify.student = studentGrade.student;
                studentGradeToModify.Grade = studentGrade.Grade;

                context.StudentGrades.Update(studentGradeToModify);

                context.SaveChanges();
            }
            catch (Exception err)
            {

                this.logger.LogError($"Error: {err.Message}", err.ToString());
            }
        }
    }
}
