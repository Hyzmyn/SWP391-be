using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class AdoptionRegistrationFormRequest
    {
        public string SocialAccount { get; set; }
        public decimal IncomeAmount { get; set; }
        public IFormFile IdentificationImage { get; set; } // Changed to IFormFile for image upload
        public IFormFile IdentificationImageBackSide { get; set; } // Changed to IFormFile for image upload
        public int AdopterId { get; set; }
        public int ShelterStaffId { get; set; }
        public int PetId { get; set; }
    }

}
