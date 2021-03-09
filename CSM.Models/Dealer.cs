using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Dealer
    {
        public int Id { get; set; }
        public string DealerName { get; set; }
        public string DealerNo { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isOnline { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool DeleteButton { get; set; }
    }
}
