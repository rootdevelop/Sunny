using System;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Sunny.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Sunny.Core.Utils;

namespace Sunny.Core.Business
{
    public static class Mission
    {
        static IList<Domain.Mission> _missions;

        public static async Task<IList<Domain.Mission>> GetMissions()
        {
            return await Retry.DoAsync(async () =>
            {

                _missions = await Mvx.Resolve<IMissionService>().GetMissions();
                return _missions;

            }, new TimeSpan(0,0,0,3));
        }

        public static async Task<Domain.Mission> GetMission(int id)
        {
            return _missions.FirstOrDefault(x => x.Id == id);
        }
    }
}

