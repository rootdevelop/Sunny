using System;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Sunny.Core.Services.Interfaces;
using System.Collections.Generic;

namespace Sunny.Core.Business
{
    public static class Mission
    {
        public static async Task<IList<Domain.Mission>> GetMissions()
        {
            return await Mvx.Resolve<IMissionService>().GetMissions();  
        }
    }
}

