using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class AppointmentTracker
    {
        #region Appointment Details

        public string LicencePlate { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<float> TotalPrice { get; set; }
        public Nullable<decimal> TotalTime { get; set; }

        #endregion

        #region Dealer
        
        public string DealerName { get; set; }

        #endregion

        #region Mechanic

        public string MechanicName { get; set; }
        public string MobileNo { get; set; }
        #endregion

        #region Service Details

        public string ServiceName { get; set; }

        #endregion


    }
}
