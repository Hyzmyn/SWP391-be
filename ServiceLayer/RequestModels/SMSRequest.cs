using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class SMSRequest
    {
        public string To { get; set; }
        public string Message { get; set; }
    }
}
