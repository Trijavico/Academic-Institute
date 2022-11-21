namespace Institute.BLL.Core
{
    public class DtoCourseBase : DtoAudit
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
