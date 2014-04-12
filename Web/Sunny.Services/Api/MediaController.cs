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
    public class MediaController : ApiController
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET api/Media
        public IQueryable<Media> GetMedias()
        {
            return _db.Medias;
        }

        // GET api/Media/5
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> GetMedia(int id)
        {
            Media media = await _db.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            return Ok(media);
        }

        // PUT api/Media/5
        public async Task<IHttpActionResult> PutMedia(int id, Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != media.Id)
            {
                return BadRequest();
            }

            _db.Entry(media).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(id))
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

        // POST api/Media
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> PostMedia(Media media)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Medias.Add(media);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = media.Id }, media);
        }

        // DELETE api/Media/5
        [ResponseType(typeof(Media))]
        public async Task<IHttpActionResult> DeleteMedia(int id)
        {
            Media media = await _db.Medias.FindAsync(id);
            if (media == null)
            {
                return NotFound();
            }

            _db.Medias.Remove(media);
            await _db.SaveChangesAsync();

            return Ok(media);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MediaExists(int id)
        {
            return _db.Medias.Count(e => e.Id == id) > 0;
        }
    }
}