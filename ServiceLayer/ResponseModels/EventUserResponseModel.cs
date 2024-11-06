using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
	public class EventUserResponseModel
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public int EventId { get; set; }
		public string EventName { get; set; }
		public bool? Status { get; set; }
	}

	public class DetailEventUserViewModel
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string UserEmail { get; set; }
		public int EventId { get; set; }
		public string EventName { get; set; }
		public string EventDescription { get; set; }
		public DateTime? EventStartDate { get; set; }
		public DateTime? EventEndDate { get; set; }
		public bool? Status { get; set; }
	}
}
