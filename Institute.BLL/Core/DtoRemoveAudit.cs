

namespace Institute.BLL.Core
{
    public class DtoRemoveAudit
    {
        public int Id { get; set; }
        public bool UserDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
