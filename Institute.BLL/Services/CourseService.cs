using System;
using System.Linq;
using Institute.BLL.Contracts;
using Institute.BLL.Core;
using Institute.BLL.Dtos;
using Institute.DAL.Entities;
using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;

namespace Institute.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRespository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILoggerService<CourseService> loggerService;
        private object courseRepository;

        public CourseService(ICourseRepository courseRespository,
                              IDepartmentRepository departmentRepository,
                              ILoggerService<CourseService> loggerService
                              )
        {
            this.courseRespository = courseRespository;
            this.departmentRepository = departmentRepository;
            this.loggerService = loggerService;
        }

        public ServiceResult GetById(int Id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var course = courseRepository.GetCourse(Id);
                result.Data = new Models.CourseModel();


            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ha ocurrido un error obteniendo el curso";
                this.loggerService.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult GetCoursesByDeparments()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var query = (from course in courseRespository.GetAll()
                             join depto in this.departmentRepository.GetAll() on course.DepartmentID equals depto.DepartmentID
                             select new Models.CourseModel()
                             {
                                 Credits = course.Credits,
                                 Department = depto.Name,
                                 Id = course.CourseID,
                                 DepartmentId = (int)depto.DepartmentID,
                                 Title = course.Title
                             }).ToList();

                result.Data = query;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ha ocurrido un error obteniendo los cursos";
                this.loggerService.LogError(result.Message, ex.ToString());
            }
            return result;
        }
        public ServiceResult SaveCourse(SaveCourseDto saveCourseDto)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Course course = new Course()
                {
                    Credits = saveCourseDto.Credits,
                    Title = saveCourseDto.Title,
                    DepartmentID = saveCourseDto.DepartmentId
                };
            }
            catch (Exception ex)
            {
                result.Message = $"Error guardando el curso {ex.Message}";
                this.loggerService.LogError(result.Message, ex.ToString());

            }
            return result;
        }
        public ServiceResult UpdateCourse(UpdateCourse studentSaveDto)
        {
            throw new NotImplementedException();
        }
    }
}
