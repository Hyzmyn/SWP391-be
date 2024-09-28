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
        public int UserID { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AdoptionStatus { get; set; } = null!;
        public int StatusId { get; set; }
        public string? Image { get; set; } 
    }

    // PetUpdateRequestModel: Dùng khi cập nhật một Pet
    public class PetUpdateRequestModel
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AdoptionStatus { get; set; } = null!;
        public string? Image { get; set; }
    }   
}
