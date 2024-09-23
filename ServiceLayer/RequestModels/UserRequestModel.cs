using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class UserCreateRequestModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool Status { get; set; }
    }

    public class UserUpdateRequestModel
    {
        public string Username { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public bool Status { get; set; }
    }
}
