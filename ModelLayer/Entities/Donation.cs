using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class Donation : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public int DonorId { get; set; }

        [ForeignKey("Shelter")]
        public int ShelterId { get; set; }

        public virtual User? User { get; set; }
        public virtual Shelter? Shelter { get; set; }
    }
}
