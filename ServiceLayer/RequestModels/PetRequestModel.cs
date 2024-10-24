using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    // PetCreateRequestModel: Dùng khi tạo mới một Pet
    public class PetCreateRequestModel
    {
        public int ShelterID { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Breed { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? AdoptionStatus { get; set; }
        //public string? Image { get; set; }
        public IFormFile? Image { get; set; }

    }

    // PetUpdateRequestModel: Dùng khi cập nhật một Pet
    public class PetUpdateRequestModel
    {
        public int ShelterID { get; set; }
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Breed { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public string? AdoptionStatus { get; set; }
        public IFormFile? Image { get; set; }

    }
    public class CreatePetStatusRequest
    {
        //public int PetId { get; set; }
        public int StatusId { get; set; }
    }
    public class UpdateAdoptionStatusRequest
    {
        public int Status { get; set; } // Enum for status: 1 for "Available", 2 for "Adopted"
        public int? UserId { get; set; } 
    }

}
