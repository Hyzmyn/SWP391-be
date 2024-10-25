using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class PetStatus
    {
        public int PetId { get; set; }
        public int StatusId { get; set; }

        public virtual Pet? Pet { get; set; }
        public virtual Status? Status { get; set; }
    }
}
