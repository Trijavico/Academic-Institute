
using Institute.BLL.Core;

namespace Institute.BLL.Dto
{
	public class StudentDTO : IPerson
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public DateTime EnrollmentDate { get; set; }
		public string EnrollmentDateDisplay { get; set; } = string.Empty;
	}
}
