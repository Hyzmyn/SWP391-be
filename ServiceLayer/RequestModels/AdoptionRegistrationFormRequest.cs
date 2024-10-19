using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class FormCreateRequest
    {
        public string SocialAccount { get; set; }
        public decimal IncomeAmount { get; set; }
        public IFormFile IdentificationImage { get; set; } 
        public IFormFile IdentificationImageBackSide { get; set; } 
        public int AdopterId { get; set; }
        public int PetId { get; set; }

    }
    public class FormUpdateRequest
    {
        public string? SocialAccount { get; set; }
        public decimal? IncomeAmount { get; set; }
        public IFormFile? IdentificationImage { get; set; }
        public IFormFile? IdentificationImageBackSide { get; set; }
        public int? AdopterId { get; set; }
        public int? ShelterStaffId { get; set; }
        public int? PetId { get; set; }
        public bool? Status { get; set; }

    }

}
