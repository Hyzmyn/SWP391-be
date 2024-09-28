using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class ShelterRequestModel
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int Capacity { get; set; }
        public string Email { get; set; } = null!;
        public string Website { get; set; } = null!;
        public decimal DonationAmount { get; set; }
    }

}
