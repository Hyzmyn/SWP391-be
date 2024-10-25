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
	public class EventWithUserResponseModel
	{
		public EventResponseModel Event { get; set; }
		public UserResponseModel User { get; set; }
	}

	public class UserResponseModel
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Location { get; set; }
		public decimal? TotalDonation { get; set; }
		public decimal? Wallet { get; set; }
		public string Image { get; set; }
		public bool? Status { get; set; }
	}
}
