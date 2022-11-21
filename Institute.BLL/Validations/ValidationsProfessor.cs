
using Institute.BLL.Core;
using Institute.BLL.Responses;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsProfessor
    {
        public static ServiceResult IsValidProfessor(DtoProfessorBase professorBase, IProfessorRepository professorRepository)
        {
            ServiceResult result = new ServiceResult();

            var resutlIsValid = ValidationsPerson.IsValidPerson(professorBase);


            if (resutlIsValid.Success)
            {
                if (professorBase.HireDate.HasValue)
                {
                    // Verificar si el estudiante esta inscripto //
                    if (professorRepository.Exists(st =>
                        st.FirstName == professorBase.FirstName
                        && st.LastName == professorBase.LastName
                        && st.HireDate == professorBase.HireDate))
                    {
                        result.Success = false;
                        result.Message = "Este professor ya se encuentra registrado.";
                        return result;
                    }

                }
                else
                {
                    result.Success = false;
                    result.Message = "La fecha de contratacion es requerida.";
                    return result;
                }
            }
            else
            {
                result.Success = resutlIsValid.Success;
                result.Message = resutlIsValid.Message;
                return result;
            }

                return result;
        }
    }
}
