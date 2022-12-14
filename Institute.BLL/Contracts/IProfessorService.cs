
using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.BLL.Responses;

namespace Institute.BLL.Contracts
{
    public interface IProfessorService : IBaseService
    {
        ProfessorResponse SaveProfessor(ProfessorSaveDto professorSaveDto);
        ProfessorUpdateResponse UpdateProfessor(ProfessorUpdateDto studentSaveDto);
        ServiceResult RemoveProfessor(ProfessorRemoveDto studentSaveDto);
    }
}
