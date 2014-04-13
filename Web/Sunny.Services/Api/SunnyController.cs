using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sunny.Services.Data;
using Sunny.Services.Domain;
using Sunny.Services.Services;

namespace Sunny.Services.Api
{
    [RoutePrefix("api")]
    public class SunnyController : ApiController
    {
        private SunnyDatabaseContext _db = new SunnyDatabaseContext();

        private static Timer _timer;

        [ResponseType(typeof(bool))]
        [Route("InitSunnyPush/{id}")]
        [HttpGet]
        public async Task<IHttpActionResult> InitPushForMission(int id)
        {
            _timer = new Timer(Callback, id, new TimeSpan(0,0,1,0), new TimeSpan(-1));

            return Ok(true);
        }

        private async void Callback(object state)
        {
            int missionsId = Convert.ToInt32(state);

            var mission = await _db.Missions.FindAsync(missionsId);
            mission.LiveStream = true;

            await _db.SaveChangesAsync();

            await PushService.SendNotification(String.Format("Live stream for '{0}' has started!", mission.Name));
        }
    }
}
