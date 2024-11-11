using Domain.Entities;
using ModelLayer.Entities;
using ModelLayer.Entities.Momo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Location { get; set; }
        public string? Token { get; set; }
        public decimal? TotalDonation { get; set; }
        public decimal? wallet { get; set; }
        public int? Point { get; set; }
        public string? Image { get; set; }
        public int? ShelterId { get; set; }
        public bool? Status { get; set; }


        public virtual Shelter? Shelter { get; set; }
        public virtual ICollection<EventUser>? Events { get; set; }
        public virtual ICollection<VnPayTransaction>? VnPay { get; set; }
        public virtual ICollection<MomoPay> MomoPays { get; set; }

        public virtual ICollection<UserRole>? UserRoles { get; set; }
        public virtual ICollection<Pet>? Pets { get; set; }
        public virtual ICollection<AdoptionRegistrationForm>? AdoptionRegistrationForms { get; set; }
        public virtual ICollection<Notification>? Notifications { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public virtual ICollection<Donation>? Donations { get; set; }
        public virtual ICollection<Certification>? Certifications { get; set; }

    }
}