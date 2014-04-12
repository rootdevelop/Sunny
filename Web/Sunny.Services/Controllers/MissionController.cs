using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Sunny.Services.Data;
using Sunny.Services.Domain;

namespace Sunny.Services.Controllers
{
    public class MissionController : Controller
    {
        private SunnyDatabaseContext db = new SunnyDatabaseContext();

        // GET: /Mission/
        public async Task<ActionResult> Index()
        {
            return View(await db.Missions.ToListAsync());
        }

        // GET: /Mission/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // GET: /Mission/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Mission/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Name,Date,Text,Location,Tags,ThumbnailUri,ImageUri")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Missions.Add(mission);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mission);
        }

        // GET: /Mission/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: /Mission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Name,Date,Text,Location,Tags,ThumbnailUri,ImageUri")] Mission mission)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mission).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mission);
        }

        // GET: /Mission/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mission mission = await db.Missions.FindAsync(id);
            if (mission == null)
            {
                return HttpNotFound();
            }
            return View(mission);
        }

        // POST: /Mission/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Mission mission = await db.Missions.FindAsync(id);
            db.Missions.Remove(mission);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
