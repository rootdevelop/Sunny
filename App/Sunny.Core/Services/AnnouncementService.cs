using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sunny.Core.Domain;
using Sunny.Core.Net;
using Sunny.Core.Services.Interfaces;

namespace Sunny.Core.Services
{
    public class AnnouncementService: IAnnouncementService
    {
        private readonly WebApiClient _client;

        public AnnouncementService()
        {
            _client = new WebApiClient(Constants.BaseUrl);
        }

        public async Task<IList<Announcement>> GetAnnouncementForMissionId(int missionId)
        {
            return await _client.GetAsync<IList<Domain.Announcement>>(String.Format("Announcement/{0}", missionId));
        }
    } 
}