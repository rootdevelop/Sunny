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
    public class AnnouncementController : Controller
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET: /Announcement/
        public async Task<ActionResult> Index()
        {
            var announcements = _db.Announcements.Include(a => a.Mission);
            return View(await announcements.ToListAsync());
        }

        // GET: /Announcement/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await _db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // GET: /Announcement/Create
        public ActionResult Create()
        {
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name");
            return View();
        }

        // POST: /Announcement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Title,IntroText,Text,ThumbnailUri,ImageUri,CreatedDate,ModifiedDate,MissionId")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _db.Announcements.Add(announcement);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", announcement.MissionId);
            return View(announcement);
        }

        // GET: /Announcement/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await _db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", announcement.MissionId);
            return View(announcement);
        }

        // POST: /Announcement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Title,IntroText,Text,ThumbnailUri,ImageUri,CreatedDate,ModifiedDate,MissionId")] Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(announcement).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", announcement.MissionId);
            return View(announcement);
        }

        // GET: /Announcement/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Announcement announcement = await _db.Announcements.FindAsync(id);
            if (announcement == null)
            {
                return HttpNotFound();
            }
            return View(announcement);
        }

        // POST: /Announcement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Announcement announcement = await _db.Announcements.FindAsync(id);
            _db.Announcements.Remove(announcement);
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
