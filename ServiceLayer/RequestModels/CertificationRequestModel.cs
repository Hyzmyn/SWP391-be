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
        [Required]
        public string Image { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int ShelterStaffId { get; set; }

        [Required]
        public int PetId { get; set; }
    }

}
