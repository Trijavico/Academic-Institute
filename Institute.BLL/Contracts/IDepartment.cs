using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface IDepartmentService : IBaseService
    {
        DepartmentResponse SaveDepartment(DepartmentSaveDto departmentSaveDto);
        DepartmentUpdateResponse UpdateDepartment(DepartmentUpdateDto departmentSaveDto);
        ServiceResult RemoveDepartment(DepartmentRemoveDto studentSaveDto);
    }
}