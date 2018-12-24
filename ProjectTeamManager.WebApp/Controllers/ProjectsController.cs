using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using ProjectTeamManager.Common;
using ProjectTeamManager.Model.DAL;

namespace ProjectTeamManager.WebApp.Controllers
{
    public class ProjectsController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();
        // GET: Projects
        public ActionResult Index()
        {
            return View(db.Projects.Where(s => !s.IsDeleted).ToList());
        }
        [HttpPost]
        // GET: Projects
        public ActionResult Index(string search, string startDate, string endDate)
        {
            var Lists = db.Projects.Where(s => !s.IsDeleted);
            string searchString = StringHelpers.ConvertToUnSign(search).ToLower();
            IEnumerable<Project> result = Lists.ToList().FindAll(
                delegate (Project p)
                {
                    if (StringHelpers.ConvertToUnSign(p.Name.ToLower()).Contains(searchString))
                        return true;
                    else
                        return false;
                }
            );
            if (!String.IsNullOrEmpty(startDate))
            {
                DateTime DT = Convert.ToDateTime(startDate);
                result = result.Where(s => s.StartDate >= DT);
            }
            if (!String.IsNullOrEmpty(endDate))
            {
                DateTime DE = Convert.ToDateTime(endDate);
                result = result.Where(s => s.EndDate <= DE);
            }
            return View(result);
        }
        // GET: Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,StartDate,EndDate,ClientName,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] Project project)
        {
            AuditTable.InsertAuditFields(project);
            //var entity = db.Projects.Where(p => p.Id != project.Id && p.Name == project.Name && !p.IsDeleted);
            //if (entity != null && entity.Count() > 0)
            //{
            //    ModelState.AddModelError("Name", "Employee is existed in database.");
            //}
            if (ModelState.IsValid)
            {
                project.Id = Guid.NewGuid();
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,EndDate,ClientName,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var entityExist = db.UserStories.Where(s => s.ProjectId == id && !s.IsDeleted).FirstOrDefault();
            if (entityExist != null)
            {
                TempData["msg"] = "<script>alert('Employee is used in UserStory table.');</script>";
            }
            else
            {
                Project project = db.Projects.Find(id);
                project.IsDeleted = true;
                db.SaveChanges();
            }
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
