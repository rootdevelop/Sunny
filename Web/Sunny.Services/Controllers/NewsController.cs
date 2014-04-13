using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sunny.Services.Domain;
using Sunny.Services.Data;

namespace Sunny.Services.Controllers
{
    public class NewsController : Controller
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET: /News/
        public async Task<ActionResult> Index()
        {
            var news = _db.News.Include(n => n.Mission);
            return View(await news.ToListAsync());
        }

        // GET: /News/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // GET: /News/Create
        public ActionResult Create()
        {
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name");
            return View();
        }

        // POST: /News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Title,IntroText,Text,ThumbnailUri,ImageUri,CreatedDate,ModifiedDate,MissionId")] News news)
        {
            if (ModelState.IsValid)
            {
                _db.News.Add(news);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", news.MissionId);
            return View(news);
        }

        // GET: /News/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", news.MissionId);
            return View(news);
        }

        // POST: /News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Title,IntroText,Text,ThumbnailUri,ImageUri,CreatedDate,ModifiedDate,MissionId")] News news)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(news).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", news.MissionId);
            return View(news);
        }

        // GET: /News/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = await _db.News.FindAsync(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: /News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            News news = await _db.News.FindAsync(id);
            _db.News.Remove(news);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
