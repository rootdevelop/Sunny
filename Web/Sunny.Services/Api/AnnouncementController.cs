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
    public class AnnouncementController : ApiController
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET api/Announcement/5
        public async Task<IList<Announcement>> GetAnnouncement(int id)
        {
            return await (from n in _db.Announcements
                          where n.Mission.Id == id
                          select n).ToListAsync();
        }

        // PUT api/Announcement/5
        public async Task<IHttpActionResult> PutAnnouncement(int id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.Id)
            {
                return BadRequest();
            }

            _db.Entry(announcement).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id))
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

        // POST api/Announcement
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> PostAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Announcements.Add(announcement);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = announcement.Id }, announcement);
        }

        // DELETE api/Announcement/5
        [ResponseType(typeof(Announcement))]
        public async Task<IHttpActionResult> DeleteAnnouncement(int id)
        {
            Announcement announcement = await _db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return NotFound();
            }

            _db.Announcements.Remove(announcement);
            await _db.SaveChangesAsync();

            return Ok(announcement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnouncementExists(int id)
        {
            return _db.Announcements.Count(e => e.Id == id) > 0;
        }
    }
}