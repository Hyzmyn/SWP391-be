using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class Event : BaseEntity
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public virtual Shelter? Shelter { get; set; }

        public virtual ICollection<EventUser>? Users { get; set; }
    }
}
