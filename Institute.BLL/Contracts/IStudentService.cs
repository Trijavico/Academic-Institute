using Institute.BLL.Core;
using Institute.BLL.Dto;

namespace Institute.BLL.Contracts
{
	public interface IStudentService : IBaseService<StudentDTO>
	{
		ServiceResult<StudentDTO>  SaveStudent(StudentDTO studentSaveDto);
		ServiceResult<StudentDTO>  UpdateStudent(StudentDTO studentSaveDto);
		ServiceResult<StudentDTO> RemoveStudent(StudentDTO studentSaveDto);
	}

}