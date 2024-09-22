using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Entities
{
    public class FeedBack : BaseEntity
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public virtual Post? Post { get; set; }
    }
}
