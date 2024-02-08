

using Institute.DAL.Context;
using Institute.DAL.Core;
using Institute.DAL.Entities;
using Institute.DAL.Entities.Production;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.DAL.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly InstituteContext context;
        private readonly ILogger<StudentRepository> logger;

        public CourseRepository(InstituteContext context, ILogger<StudentRepository> logger)
            : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
