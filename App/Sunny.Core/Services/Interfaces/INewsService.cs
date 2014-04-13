using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sunny.Core.Services.Interfaces
{
    public interface INewsService
    {
        Task<IList<Domain.News>> GetNewsForMissionId(int missionId);
    }
}