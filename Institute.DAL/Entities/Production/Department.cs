

namespace Institute.DAL.Entities.Production
{
    public class Department : Core.BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Budget { get; set; }
        public string Administrator { get; set; }
        public object DepartmentID { get; set; }
    }
}
