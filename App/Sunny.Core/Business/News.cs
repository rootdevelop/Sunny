using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Sunny.Core.Services.Interfaces;
using Sunny.Core.Utils;

namespace Sunny.Core.Business
{
    public static class News
    {
        static readonly Dictionary<int, IList<Domain.News>> NewsForMission = new Dictionary<int, IList<Domain.News>>();

        public static async Task<IList<Domain.News>> GetNewsForMissionId(int id)
        {
            return await Retry.DoAsync(async () =>
            {

                var news = await Mvx.Resolve<INewsService>().GetNewsForMissionId(id);
                if (NewsForMission.ContainsKey(id))
                {
                    NewsForMission[id] = news;
                }
                else
                {
                    NewsForMission.Add(id, news);
                }
                
                return news;

            }, new TimeSpan(0, 0, 0, 3));
        }

        public static async Task<Domain.News> GetNews(int id)
        {
            return NewsForMission.SelectMany(x => x.Value.Where(y => y.Id == id)).FirstOrDefault();
        }
    }
}
