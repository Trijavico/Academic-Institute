namespace Institute.Web.Models
{
    public class Student : Person
    {
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime Birth { get; set; }


    }
}
