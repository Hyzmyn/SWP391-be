using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class CertificationRequest
    {
        //public string Image { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string Description { get; set; } = null!;

        public DateTimeOffset Date { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ShelterStaffId { get; set; }

        [Required]
        public int PetId { get; set; }
    }

}
