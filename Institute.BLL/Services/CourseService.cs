using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dtos;
using Institute.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Institute.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CourseService> _loggerService;

        public CourseService(ICourseRepository courseRespository,
                              ILogger<CourseService> loggerService
                              )
        {
            _courseRepository = courseRespository;
            _loggerService = loggerService;
        }


        public ServiceResult<CourseDTO> SaveCourse(CourseDTO courseReceived)
        {
            var result = new ServiceResult<CourseDTO>();

            try
            {
                
            }
            catch (Exception ex)
            {
                result.Message = $"Error guardando el curso {ex.Message}";
                _loggerService.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult<CourseDTO> UpdateCourse(CourseDTO courseReceived)
        {
            throw new NotImplementedException();
        }



        public ServiceResult<IEnumerable<CourseDTO>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<CourseDTO>>();
            try
            {
                var query = _courseRepository.GetEntities();

                // result.Data = query;

                // TODO: MAPPING
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error obteniendo los cursos";
                _loggerService.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<CourseDTO> GetById(int id)
        {
            var result = new ServiceResult<CourseDTO> ();

            try
            {
                var course = _courseRepository.GetEntity(id);
                result.Data = new CourseDTO(){};
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ha ocurrido un error obteniendo el curso";
                _loggerService.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
