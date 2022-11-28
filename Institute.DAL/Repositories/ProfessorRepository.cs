using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Institute.DAL.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<ProfessorRepository> logger;
        public ProfessorRepository(InstituteContext context, ILogger<ProfessorRepository> logger)
            : base(context)
        {
            this.context = context;
            this.logger = logger;
        }


    }
}
