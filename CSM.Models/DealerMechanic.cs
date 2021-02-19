using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.Models
{
    public class DealerMechanic
    {
        public int Id { get; set; }
        public int DealerId { get; set; }
        public int MechanicId { get; set; }
    }
}
