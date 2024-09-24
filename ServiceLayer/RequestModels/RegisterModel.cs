using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class AdminCreateAccountModel
    {
        //public int UserId {  get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }

    }

    public class RegisterModel : AdminCreateAccountModel
    {
        public string Password { get; set; }
    }
}
