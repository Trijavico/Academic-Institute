

using Institute.DAL.Entities.Production;

namespace Institute.DAL.Entities
{
    public class Course : Core.BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }
        public int DepartmentID { get; set; }
        public int CourseID { get; set; }
    }
}
