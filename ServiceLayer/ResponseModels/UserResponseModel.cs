using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class UsersResponseModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal TotalDonation { get; set; }

    }

    public class UserDetailResponse : UsersResponseModel
    {
        public double RatingCount { get; set; }
    }
}
