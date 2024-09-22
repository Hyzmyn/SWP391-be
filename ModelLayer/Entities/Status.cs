using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Disease { get; set; }
        public string Vaccine { get; set; }

        public virtual Pet? Pet { get; set; }
    }
}
