
namespace Institute.BLL.Core
{
    public class DtoAudit : DtoUpdateAudit
    {
        public int UserId { get; set; }
        public DateTime AuditDate { get; set; }
    }
}
