using System;

namespace Institute.BBL.Core
{
    public class DtoDepartmentBase : DtoAudit
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
