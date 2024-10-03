using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class NotificationRequestModel
    {
        [Required]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string Message { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
