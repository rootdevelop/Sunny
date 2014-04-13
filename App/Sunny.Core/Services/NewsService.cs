using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sunny.Core.Domain;
using Sunny.Core.Net;
using Sunny.Core.Services.Interfaces;

namespace Sunny.Core.Services
{
    public class NewsService: INewsService
    {
        private readonly WebApiClient _client;

        public NewsService()
        {
            _client = new WebApiClient(Constants.BaseUrl);
        }

        public async Task<IList<News>> GetNewsForMissionId(int missionId)
        {
            return await _client.GetAsync<IList<Domain.News>>(String.Format("News/{0}", missionId));
        }
    } 
}