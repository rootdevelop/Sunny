using System.Threading.Tasks;
using Cirrious.CrossCore;
using Sunny.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Sunny.Core.Business
{
    public static class Mission
    {
        static IList<Domain.Mission> _missions;

        public static async Task<IList<Domain.Mission>> GetMissions()
        {
            _missions = await Mvx.Resolve<IMissionService>().GetMissions();  
            return _missions;
        }

        public static async Task<Domain.Mission> GetMission(int id)
        {
            return _missions.FirstOrDefault(x => x.Id == id);
        }
    }
}

