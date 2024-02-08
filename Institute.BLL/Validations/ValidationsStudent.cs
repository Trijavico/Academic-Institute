using Institute.BLL.Core;
using Institute.BLL.Dto;
using Institute.DAL.Interfaces;

namespace Institute.BLL.Validations
{
    public class ValidationsStudent
    {
        public static ServiceResult<StudentDTO> IsValidStudent(StudentDTO studentReceived, IStudentRepository studentRepository)
        {
            var result = new ServiceResult<StudentDTO>();

            var isValidPersonResult = ValidationsPerson.IsValidPerson(studentReceived);


            if (isValidPersonResult.Success)
            {
                // Verificar si el estudiante esta inscripto //
                if (studentRepository.Exists(st =>
                    st.FirstName == studentReceived.FirstName
                    && st.LastName == studentReceived.LastName
                    && st.EnrollmentDate == studentReceived.EnrollmentDate))
                {
                    result.Success = false;
                    result.Message = "Este Estudiante ya se encuentra registrado.";
                    return result;
                }
            }
            else
            {
                result.Success = isValidPersonResult.Success;
                result.Message = isValidPersonResult.Message;
                return result;
            }

            result.Data = studentReceived;
            
            return result;
        }
    }
}