using Institute.BLL.Core;


namespace Institute.BLL.Validations
{
    public static class ValidationCourse
    {
        public static ServiceResult IsValidCourse(DtoCourseBase course)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(course.Title))
            {
                result.Success = false;
                result.Message = "El nombre del curso es requerido.";
                return result;
            }

            if (course.Title.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del titulo es inválida.";
                return result;
            }


            return result;
        }
    }
}

