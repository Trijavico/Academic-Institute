
using Institute.BLL.Core;
using Institute.BLL.Dto;

namespace Institute.BLL.Contracts
{
    public interface IProfessorService : IBaseService<ProfessorDTO>
    {
        ServiceResult<ProfessorDTO> SaveProfessor(ProfessorDTO professorSave);
        ServiceResult<ProfessorDTO> UpdateProfessor(ProfessorDTO professorUpdate);
        ServiceResult<ProfessorDTO> RemoveProfessor(ProfessorDTO professorRemove);
    }
}
