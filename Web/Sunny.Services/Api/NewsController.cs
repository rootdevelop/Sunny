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
    public class NewsController : ApiController
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET api/News/5
        public async Task<IList<News>> GetNews(int id)
        {
            if (id == 0)
            {
                return await (from n in _db.News
                              where n.Mission == null
                              select n).ToListAsync();
            }

            return await (from n in _db.News
                              where n.Mission.Id == id
                              select n).ToListAsync();
        }

        // PUT api/News/5
        public async Task<IHttpActionResult> PutNews(int id, News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != news.Id)
            {
                return BadRequest();
            }

            _db.Entry(news).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(id))
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

        // POST api/News
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> PostNews(News news)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.News.Add(news);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = news.Id }, news);
        }

        // DELETE api/News/5
        [ResponseType(typeof(News))]
        public async Task<IHttpActionResult> DeleteNews(int id)
        {
            News news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

            _db.News.Remove(news);
            await _db.SaveChangesAsync();

            return Ok(news);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NewsExists(int id)
        {
            return _db.News.Count(e => e.Id == id) > 0;
        }
    }
}