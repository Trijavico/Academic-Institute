using Institute.DAL.Context;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

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

    }
}
