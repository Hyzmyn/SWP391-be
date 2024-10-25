﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class UserRoleResponseModel
    {
        public int UserId { get; set; }
        public List<string> Roles { get; set; }
    }

    public class RoleDetailResponseModel : UserRoleResponseModel
    {
        public RoleResponseModel Role { get; set; } = null!;
    }

    public class PendingRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
