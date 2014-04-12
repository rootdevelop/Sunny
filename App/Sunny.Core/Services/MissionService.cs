using System;
using Sunny.Core.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sunny.Core.Net;

namespace Sunny.Core.Services
{
    public class MissionService : IMissionService
    {
        WebApiClient _client;

        public MissionService()
        {
            _client = new WebApiClient(Constants.BaseUrl);
        }

        public Task<IList<Domain.Mission>> GetMissions()
        {
            return _client.GetAsync<IList<Domain.Mission>>("Mission");
        }
    }
}

