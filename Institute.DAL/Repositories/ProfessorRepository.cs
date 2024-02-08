using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        private readonly InstituteContext _context;
        private readonly ILogger<ProfessorRepository> _logger;
        public ProfessorRepository(InstituteContext context, ILogger<ProfessorRepository> logger)
            : base(context)
        {
            _context = context;
            _logger = logger;
        }


    }
}
