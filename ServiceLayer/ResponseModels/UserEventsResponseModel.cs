using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ResponseModels
{
    public class UserEventResponseModel
    {
        public int UserId { get; set; }
        public List<string> Events { get; set; }
    }
}
