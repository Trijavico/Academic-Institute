using Institute.Web.Models;

namespace Institute.Web.Extensions
{
    public static class ProfessorExtensions
    {
        public static List<Professor> ConvertStudentModelToModel(this List<BLL.Models.ProfessorModel> professorModels)
        {
            var myProfessors = professorModels.Select(item => new Professor()
            {
                LastName = item.LastName,
                FirstName = item.FirstName,
                Id = item.Id,
                HireDate = item.HireDate
            }).ToList();

            return myProfessors;

        }
    }
}
