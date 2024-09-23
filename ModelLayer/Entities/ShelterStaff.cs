using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class ShelterStaff : BaseEntity
    {
        public int UserId { get; set; }
        public int ShelterId { get; set; }

        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Shelter>? Shelters { get; set; }
    }
}
