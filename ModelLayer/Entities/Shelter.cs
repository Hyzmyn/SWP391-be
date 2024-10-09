using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class Shelter : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public int Capaxity { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public decimal? DonationAmount { get; set; }

        public virtual ICollection<Pet>? Pets { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Donation>? Donations { get; set; }

    }
}
