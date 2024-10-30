using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class SMSRequest
    {
        [Required]
        public string To { get; set; }

        [MaxLength(200)]
        [Required]
        public string Message { get; set; }
    }
}
