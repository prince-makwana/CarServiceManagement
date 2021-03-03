using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class Planning
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public int MechanicId { get; set; }
        public int AppointmentServiceId { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<System.DateTime> Duration { get; set; }

    }
}
