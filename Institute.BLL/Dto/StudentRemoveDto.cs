using Institute.BLL.Core;
using System;

namespace Institute.BLL.Dtos
{
	public class StudentRemoveDto : DtoAudit
	{
		public bool Deleted { get; set; }
	}
}