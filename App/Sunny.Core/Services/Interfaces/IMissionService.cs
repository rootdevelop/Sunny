using System;
using System.Threading.Tasks;
using System.Collections;
using Sunny.Core.Domain;
using System.Collections.Generic;

namespace Sunny.Core.Services.Interfaces
{
    public interface IMissionService
    {
        Task<IList<Domain.Mission>> GetMissions();
        Task InitPush(int missionId);
    }
}

