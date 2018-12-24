using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ProjectTeamManager.Common;
using ProjectTeamManager.Model.DAL;

namespace ProjectTeamManager.WebApp.Controllers
{
    public class UserStoriesController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();
        // GET: UserStories
        public ActionResult Index()
        {
            var userStories = db.UserStories.Include(u => u.Project).Where(s => !s.IsDeleted && !s.Project.IsDeleted);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted).Select(s => s), "Id", "Name");
            return View(userStories.ToList());
        }
        [HttpPost]
        public ActionResult Index(Guid? projectId, string search)
        {
            var userStories = db.UserStories.Include(u => u.Project.IsDeleted).Where(s => !s.IsDeleted && !s.Project.IsDeleted);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted).Select(s => s), "Id", "Name");
            string searchString = StringHelpers.ConvertToUnSign(search).ToLower();
            IEnumerable<UserStory> result = userStories.ToList().FindAll(
                delegate (UserStory user)
                {
                    if (StringHelpers.ConvertToUnSign(user.Story.ToLower()).Contains(searchString))
                        return true;
                    else
                        return false;
                }
            );
            if (projectId != null)
            {
                result = result.Where(s => s.ProjectId == projectId);
            }
            return View(result);
        }

        // GET: UserStories/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            return View();
        }

        // POST: UserStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Story,ProjectId,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] UserStory userStory)
        {
            AuditTable.InsertAuditFields(userStory);
            if (ModelState.IsValid)
            {
                userStory.Id = Guid.NewGuid();
                db.UserStories.Add(userStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted).Select(s => s), "Id", "Name", userStory.ProjectId);
            return View(userStory);
        }

        // GET: UserStories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.UserStories.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted).Select(s => s), "Id", "Name", userStory.ProjectId);
            return View(userStory);
        }

        // POST: UserStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Story,ProjectId,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] UserStory userStory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userStory).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(userStory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted).Select(s => s), "Id", "Name", userStory.ProjectId);
            return View(userStory);
        }

        // GET: UserStories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserStory userStory = db.UserStories.Find(id);
            if (userStory == null)
            {
                return HttpNotFound();
            }
            return View(userStory);
        }

        // POST: UserStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            UserStory userStory = db.UserStories.Find(id);
            userStory.IsDeleted = true;
            db.SaveChanges();
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
