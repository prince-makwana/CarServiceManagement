using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class UpdateAppointmentViewModel
    {
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<float> TotalPrice { get; set; }
        public Nullable<decimal> TotalTime { get; set; }
    }
}
