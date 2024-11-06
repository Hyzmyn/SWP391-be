using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
	public class EventUserCreateRequestModel
	{
		public int UserId { get; set; }
		public int EventId { get; set; }
		public bool? Status { get; set; }
	}
	public class EventUserStatusUpdateRequestModel
	{
		public bool? Status { get; set; }
	}


}
