using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Dtos;

namespace Institute.BLL.Contracts
{
    public interface ICourseService : IBaseService
    {
        ServiceResult SaveCourse(SaveCourseDto saveCourseDto);
        ServiceResult UpdateCourse(UpdateCourseDto studentSaveDto);
        ServiceResult GetCoursesByDeparments();
    }
}
