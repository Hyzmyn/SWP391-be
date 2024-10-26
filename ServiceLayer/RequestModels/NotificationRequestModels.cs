using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
	public class CreateNotificationRequestModel
	{
		public string Title { get; set; }
		public string Message { get; set; } = null!;
		public DateTime Date { get; set; }
		public int UserId { get; set; }
	}

	public class UpdateNotificationRequestModel
	{
		public string Title { get; set; }

		public string Message { get; set; } = null!;
		public DateTime Date { get; set; }
		public int UserId { get; set; }
	}
}
