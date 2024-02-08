
namespace Institute.DAL.Entities
{
    public class Course : Core.BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
