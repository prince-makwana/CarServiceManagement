using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string LicencePlate { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int DealerId { get; set; }
        public string DealerName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<float> TotalPrice { get; set; }
        public Nullable<decimal> TotalTime { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool DeleteButton { get; set; }
    }
}
