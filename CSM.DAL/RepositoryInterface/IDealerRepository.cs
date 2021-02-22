using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.DAL.RepositoryInterface
{
    public interface IDealerRepository
    {
        List<Dealer> GetAllDealers();
        string CreateDealer(Dealer model);
        string UpdateDealer(Dealer model);
        string DeleteDealer(int id);
        List<DealerObj> DealersDropdown();
    }
}
