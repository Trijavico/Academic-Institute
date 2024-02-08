using Institute.Web.Models;

namespace Institute.Web.Extensions
{
    public static class ProfessorExtensions
    {
        public static List<Professor> ConverToModel(List<BLL.Dto.ProfessorDTO> professorModels)
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
