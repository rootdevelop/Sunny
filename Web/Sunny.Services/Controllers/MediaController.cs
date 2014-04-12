using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sunny.Services.Data;
using Sunny.Services.Domain;

namespace Sunny.Services.Controllers
{
    public class MediaController : Controller
    {
        private readonly SunnyDatabaseContext _db = new SunnyDatabaseContext();

        // GET: /Media/
        public async Task<ActionResult> Index()
        {
            var medias = _db.Medias.Include(m => m.Mission);
            return View(await medias.ToListAsync());
        }

        // GET: /Media/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await _db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // GET: /Media/Create
        public ActionResult Create()
        {
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name");
            return View();
        }

        // POST: /Media/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,ThumbnailUri,ImageUri,Description,Title,Date,Location,Tags,MissionId,MediaType")] Media media)
        {
            if (ModelState.IsValid)
            {
                _db.Medias.Add(media);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", media.MissionId);
            return View(media);
        }

        // GET: /Media/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await _db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", media.MissionId);
            return View(media);
        }

        // POST: /Media/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,ThumbnailUri,ImageUri,Description,Title,Date,Location,Tags,MissionId,MediaType")] Media media)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(media).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.MissionId = new SelectList(_db.Missions, "Id", "Name", media.MissionId);
            return View(media);
        }

        // GET: /Media/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Media media = await _db.Medias.FindAsync(id);
            if (media == null)
            {
                return HttpNotFound();
            }
            return View(media);
        }

        // POST: /Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Media media = await _db.Medias.FindAsync(id);
            _db.Medias.Remove(media);
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
