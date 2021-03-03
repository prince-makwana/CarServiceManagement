using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string MechanicName { get; set; }
        public string EmployeeNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int DealerId { get; set; }
    }
}
