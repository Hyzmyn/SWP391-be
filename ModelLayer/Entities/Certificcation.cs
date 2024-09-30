using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class Certification : BaseEntity
    {
        public string Image { get; set; }
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        public int ShelterStaffId { get; set; }

        public int PetId { get; set; }

        public virtual ICollection<User>? User { get; set; }
        public virtual Pet? Pet { get; set; }
    }
}
