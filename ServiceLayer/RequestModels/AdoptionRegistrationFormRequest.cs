using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.RequestModels
{
    public class AdoptionRegistrationFormRequest
    {
        public string IdentityProof { get; set; }
        public decimal IncomeAmount { get; set; }
        public string Image { get; set; }
        public string Condition { get; set; }
        public int AdopterId { get; set; }
        public int ShelterStaffId { get; set; }
        public int PetId { get; set; }
    }

}
