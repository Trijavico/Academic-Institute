using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsProfessor
    {
        public static ServiceResult<ProfessorDTO> IsValidProfessor(ProfessorDTO professorReceived, IProfessorRepository professorRepository)
        {
            var result = new ServiceResult<ProfessorDTO>();
            var IsValidPersonResult = ValidationsPerson.IsValidPerson(professorReceived);

            if (IsValidPersonResult.Success)
            {
                if (professorRepository.Exists(st =>
                    st.FirstName == professorReceived.FirstName
                    && st.LastName == professorReceived.LastName
                    && st.HireDate == professorReceived.HireDate))
                {
                    result.Success = true;
                    result.Message = "This professor is already registered";
                    return result;
                }
            }
            else
            {
                result.Success = IsValidPersonResult.Success;
                result.Message = IsValidPersonResult.Message;
                return result;
            }

            result.Data = professorReceived;
            
            return result;
        }
    }
}
