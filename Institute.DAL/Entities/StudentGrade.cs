namespace Institute.DAL.Entities
{
    public class StudentGrade
    {
        public int Id { get; set; }
        public Course course { get; set; }
        public Student student { get; set; }
        public int Grade { get; set; }

    }
}
