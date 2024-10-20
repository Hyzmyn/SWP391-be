using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
	public class EventResponseModel
	{
		public int Id { get; set; }
		public int ShelterId { get; set; }
		public string Name { get; set; } = null!;
		public DateTime Date { get; set; }
		public string Description { get; set; } = null!;
		public string Location { get; set; } = null!;

		
		 
	}
	public class EventResponseModels
	{
		public int Id { get; set; }
		public int ShelterId { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }

		public List<UsersResponseModel>? Users { get; set; }
	}
}
