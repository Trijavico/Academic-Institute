using Institute.BLL.Core;
using System;

namespace Institute.BLL.Dto
{
	public class StudentRemoveDto : DtoAudit
	{
		public bool Deleted { get; set; }
	}
}
