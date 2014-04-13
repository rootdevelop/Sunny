using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sunny.Core.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<IList<Domain.Announcement>> GetAnnouncementForMissionId(int missionId);
    }
}