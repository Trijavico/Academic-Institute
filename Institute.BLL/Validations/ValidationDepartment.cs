using Institute.BLL.Core;

namespace Institute.BLL.Validations
{
    public static class DepartmentValidation
    {
        public static ServiceResult IsValidDepartment(DepartmentDto department)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(department.Name))
            {
                result.Success = false;
                result.Message = "El nombre del departamento es requerido.";
                return result;
            }

            if (department.Name.Length > 50)
            {
                result.Success = false;
                result.Message = "La longitud del nombre es inválida.";
                return result;
            }

            //if (string.IsNullOrEmpty(person.Email))
            //{
            //    result.Success = false;
            //    result.Message = "El correo electronico es requerido";
            //    return result;
            //}

            return result;
        }
    }
}