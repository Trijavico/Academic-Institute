
namespace Institute.DAL.Entities
{
    public class Student : Core.Person
    {
        public string Student_Id { get; set; } 
        public string Course { get; set; }
        public string Career { get; set; }
    }
}
