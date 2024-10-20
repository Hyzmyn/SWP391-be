using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public int? ShelterId { get; set; }
        public decimal? wallet { get; set; }
        public decimal? TotalDonation { get; set; }
        public string? Image { get; set; }
    }


    public class UserCreateRequestModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool? Status { get; set; }
        public IFormFile? Image { get; set; }
        public int? ShelterId { get; set; }
        public List<int> RoleIds { get; set; } = new List<int>();
    }

    public class UserUpdateRequestModel
    {
        public string Username { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool? Status { get; set; }  
        public IFormFile? Image { get; set; }
        public int? ShelterId { get; set; }
        public List<int>? RoleIds { get; set; }
    }
}
