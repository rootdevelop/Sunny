using Sunny.Core.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sunny.Core.Net;

namespace Sunny.Core.Services
{
    public class MissionService : IMissionService
    {
        private readonly WebApiClient _client;

        public MissionService()
        {
            _client = new WebApiClient(Constants.BaseUrl);
        }

        public async Task<IList<Domain.Mission>> GetMissions()
        {
            return await _client.GetAsync<IList<Domain.Mission>>("Mission");
        }
    }
}

