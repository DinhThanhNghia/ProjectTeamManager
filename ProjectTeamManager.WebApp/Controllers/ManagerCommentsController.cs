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
    public class ManagerCommentsController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();
        // GET: ManagerComments
        public ActionResult Index()
        {
            var managerComments = db.ManagerComments.Include(m => m.ProjectTask).Where(s => !s.IsDeleted && !s.ProjectTask.IsDeleted);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted), "Id", "Name");
            return View(managerComments.ToList());
        }
        [HttpPost]
        public ActionResult Index(Guid? projectId, string search)
        {
            var managerComments = db.ManagerComments.Include(m => m.ProjectTask).Where(s => !s.IsDeleted && !s.ProjectTask.IsDeleted);
            ViewBag.ProjectId = new SelectList(db.Projects.Where(s => !s.IsDeleted), "Id", "Name");
            string searchString = StringHelpers.ConvertToUnSign(search).ToLower();
            IEnumerable<ManagerComment> result = managerComments.ToList().FindAll(
                delegate (ManagerComment m)
                {
                    if ((StringHelpers.ConvertToUnSign(m.FirstName.ToLower()).Contains(searchString)) 
                    || (StringHelpers.ConvertToUnSign(m.LastName.ToLower()).Contains(searchString))
                    || (searchString.Contains(StringHelpers.ConvertToUnSign(m.FirstName.ToLower()))) 
                    || (searchString.Contains(StringHelpers.ConvertToUnSign(m.LastName.ToLower())))
                    )
                        return true;
                    else
                        return false;
                }
            );
            if (projectId != null)
            {
                result = result.Where(s => s.ProjectTask.UserStory.ProjectId == projectId);
            }
            return View(result);
        }

        // GET: ManagerComments/Create
        public ActionResult Create()
        {
            ViewBag.ProjectTaskId = new SelectList(db.ProjectTasks.Where(s => !s.IsDeleted).Select(s => s), "Id", "Employee.FullName");
            return View();
        }

        // POST: ManagerComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ProjectTaskId,Comments,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] ManagerComment managerComment)
        {
            AuditTable.InsertAuditFields(managerComment);
            if (ModelState.IsValid)
            {
                managerComment.Id = Guid.NewGuid();
                db.ManagerComments.Add(managerComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectTaskId = new SelectList(db.ProjectTasks.Where(s => !s.IsDeleted).Select(s => s), "Id", "Employee.FullName", managerComment.ProjectTaskId);
            return View(managerComment);
        }

        // GET: ManagerComments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerComment managerComment = db.ManagerComments.Find(id);
            if (managerComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectTaskId = new SelectList(db.ProjectTasks.Where(s => !s.IsDeleted).Select(s => s), "Id", "Employee.FullName", managerComment.ProjectTaskId);
            return View(managerComment);
        }

        // POST: ManagerComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ProjectTaskId,Comments,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] ManagerComment managerComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(managerComment).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(managerComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectTaskId = new SelectList(db.ProjectTasks.Where(s => !s.IsDeleted).Select(s => s), "Id", "Employee.FullName", managerComment.ProjectTaskId);
            return View(managerComment);
        }

        // GET: ManagerComments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ManagerComment managerComment = db.ManagerComments.Find(id);
            if (managerComment == null)
            {
                return HttpNotFound();
            }
            return View(managerComment);
        }

        // POST: ManagerComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ManagerComment managerComment = db.ManagerComments.Find(id);
            managerComment.IsDeleted = true;
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
