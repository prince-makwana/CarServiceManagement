using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string LicencePlate { get; set; }
        public string Model { get; set; }
        public Nullable<int> MeterValue { get; set; }
        public System.DateTime RegDate { get; set; }
        public Nullable<float> Weight { get; set; }
        public string MCHCode { get; set; }
        public string Vin { get; set; }
        public string EngNo { get; set; }
        public string Colour { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int CustomerId { get; set; }
    }
}
