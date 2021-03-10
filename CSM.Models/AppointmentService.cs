using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class AppointmentService
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }

        public string ServiceName{ get; set; }
        public string CostType { get; set; }
        public string SalesPart { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public float PricePerUnit { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public float FixPrice { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool DeleteButton { get; set; }
    }
}
