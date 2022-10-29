using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<ProfessorRepository> logger;
        public ProfessorRepository(InstituteContext context, ILogger<ProfessorRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public bool Exists(int professorId)
        {
            return context.Professors.Any(cd => cd.Id == professorId); 
        }

        public IEnumerable<Professor> GetAll()
        {
            return context.Professors.OrderByDescending(st => st.CreationDate);
        }

        public Professor GetProfessor(int professorId)
        {
            return context.Professors.Find(professorId);
        }

        public void Remove(Professor professor)
        {
            context.Professors.Remove(professor);
        }

        public void Save(Professor professor)
        {
            context.Professors.Add(professor);
            context.SaveChanges();
        }

        public void Update(Professor professor)
        {
            try
            {
                Professor professorToModify = GetProfessor(professor.Id);

                professorToModify.FirstName = professor.FirstName;
                professorToModify.LastName = professor.LastName;
                professorToModify.EnrollmentDate = professor.EnrollmentDate;

                context.Professors.Update(professorToModify);

                context.SaveChanges();
            }
            catch (Exception err)
            {

                this.logger.LogError($"Error: {err.Message}", err.ToString());
            }
        }
    }
}
