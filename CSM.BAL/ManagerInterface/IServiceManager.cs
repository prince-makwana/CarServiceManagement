﻿using CSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSM.BAL.ManagerInterface
{
    public interface IServiceManager
    {
        string CreateService(Service model);
        string DeleteService(int id);
        List<Service> GetAllServices();
        string UpdateService(Service model);
        List<Service> ServicesDropdown(int id);
    }
}
