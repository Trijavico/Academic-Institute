using Institute.BLL.Core;
using Institute.BLL.Dtos;

namespace Institute.BLL.Contracts
{
    public interface ICourseService : IBaseService<CourseDTO>
    {
        ServiceResult<CourseDTO> SaveCourse(CourseDTO saveCourseDto);
        ServiceResult<CourseDTO> UpdateCourse(CourseDTO studentSaveDto);
    }
}
