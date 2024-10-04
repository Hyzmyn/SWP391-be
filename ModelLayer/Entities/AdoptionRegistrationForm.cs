using Domain.Entities;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class AdoptionRegistrationForm : BaseEntity
    {
        public string SocialAccount { get; set; }
        public decimal IncomeAmount { get; set; }
        public string IdentificationImage { get; set; }
        public string IdentificationImageBackSide { get; set; }

        public int AdopterId { get; set; }
        public int ShelterStaffId { get; set; }
        public int PetId { get; set; }

        public virtual User? User { get; set; }
        public virtual Pet? Pet { get; set; }

    }
}
