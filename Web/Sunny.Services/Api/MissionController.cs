using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Sunny.Services.Domain;
using Sunny.Services.Data;

namespace Sunny.Services.Api
{
    public class MissionController : ApiController
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET api/Mission
        public IQueryable<Mission> GetMissions()
        {
            return _db.Missions;
        }

        // GET api/Mission/5
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> GetMission(int id)
        {
            Mission mission = await _db.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        // PUT api/Mission/5
        public async Task<IHttpActionResult> PutMission(int id, Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mission.Id)
            {
                return BadRequest();
            }

            _db.Entry(mission).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Mission
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> PostMission(Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Missions.Add(mission);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = mission.Id }, mission);
        }

        // DELETE api/Mission/5
        [ResponseType(typeof(Mission))]
        public async Task<IHttpActionResult> DeleteMission(int id)
        {
            Mission mission = await _db.Missions.FindAsync(id);
            if (mission == null)
            {
                return NotFound();
            }

            _db.Missions.Remove(mission);
            await _db.SaveChangesAsync();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissionExists(int id)
        {
            return _db.Missions.Count(e => e.Id == id) > 0;
        }
    }
}