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
    public static class Announcement
    {
        static readonly Dictionary<int, IList<Domain.Announcement>> AnnouncementsForMission = new Dictionary<int, IList<Domain.Announcement>>();

        public static async Task<IList<Domain.Announcement>> GetAnnouncementForMissionId(int id)
        {
            return await Retry.DoAsync(async () =>
            {

                var announcements = await Mvx.Resolve<IAnnouncementService>().GetAnnouncementForMissionId(id);
                if (AnnouncementsForMission.ContainsKey(id))
                {
                    AnnouncementsForMission[id] = announcements;
                }
                else
                {
                    AnnouncementsForMission.Add(id, announcements);
                }

                return announcements;

            }, new TimeSpan(0, 0, 0, 3));
        }

        public static async Task<Domain.Announcement> GetAnnouncement(int id)
        {
            return AnnouncementsForMission.SelectMany(x => x.Value.Where(y => y.Id == id)).FirstOrDefault();
        }
    }
}
