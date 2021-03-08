using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float FixPrice { get; set; }
        public float Discount { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
    }
}
