using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class CustomerVehicle
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string CustomerNo { get; set; }
        public string Email { get; set; }

        // Vehicle Data items
        public int VehicleId { get; set; }
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
    }
}
