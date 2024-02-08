using Institute.BLL.Core;
using Institute.BLL.Dtos;


namespace Institute.BLL.Validations
{
    public static class ValidationCourse
    {
        public static ServiceResult<CourseDTO> IsValidCourse(CourseDTO courseReceived)
        {
            var result = new ServiceResult<CourseDTO>();

            if (string.IsNullOrEmpty(courseReceived.Title))
            {
                result.Success = false;
                result.Message = "El nombre del curso es requerido.";
                return result;
            }

            if (courseReceived.Title.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del titulo es inválida.";
                return result;
            }


            return result;
        }
    }
}

