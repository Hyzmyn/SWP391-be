    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class ShelterRequestModel
    {
        public string Name { get; set; }

        public string Location { get; set; }

        public string PhoneNumber { get; set; }

        public int Capaxity { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        public string? Website { get; set; }

        public decimal? DonationAmount { get; set; }
    }

}
