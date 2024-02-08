
using Institute.BLL.Core;

namespace Institute.BLL.Dto
{
    public class ProfessorDTO : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

    }
}
