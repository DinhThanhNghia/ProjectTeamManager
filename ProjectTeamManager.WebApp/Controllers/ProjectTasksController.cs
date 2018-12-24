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
    public class ProjectTasksController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();
        // GET: ProjectTasks
        public ActionResult Index()
        {
            var projectTasks = db.ProjectTasks.Include(p => p.Employee).Include(p => p.TaskStatu).Include(p => p.UserStory).Where(s => !s.IsDeleted && !s.Employee.IsDeleted && !s.TaskStatu.IsDeleted && !s.UserStory.IsDeleted).Select(s => s);
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted), "Id", "FullName");
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted), "Id", "Status");
            return View(projectTasks.ToList());
        }
        [HttpPost]
        public ActionResult Index(Guid? EmployeeId, Guid? TaskStatusId, string startDate, string endDate)
        {
            var projectTasks = db.ProjectTasks.Include(p => p.Employee).Include(p => p.TaskStatu).Include(p => p.UserStory).Where(s => !s.IsDeleted && !s.Employee.IsDeleted && !s.TaskStatu.IsDeleted && !s.UserStory.IsDeleted).Select(s => s);
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted), "Id", "FullName");
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted), "Id", "Status");
            if (EmployeeId != null)
            {
                projectTasks = projectTasks.Where(s => s.EmployeeId == EmployeeId).Select(s => s);
            }
            if (TaskStatusId != null)
            {
                projectTasks = projectTasks.Where(s => s.TaskStatusId == TaskStatusId).Select(s => s);
            }
            if (!String.IsNullOrEmpty(startDate))
            {
                DateTime DT = Convert.ToDateTime(startDate);
                projectTasks = projectTasks.Where(s => s.TaskStartDate >= DT);
            }
            if (!String.IsNullOrEmpty(endDate))
            {
                DateTime DE = Convert.ToDateTime(endDate);
                projectTasks = projectTasks.Where(s => s.TaskEndDate <= DE);
            }
            return View(projectTasks.ToList());
        }

        // GET: ProjectTasks/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted).Select(s => s), "Id", "FullName");
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted).Select(s => s), "Id", "Status");
            ViewBag.UserStoryId = new SelectList(db.UserStories.Where(s => !s.IsDeleted).Select(s => s), "Id", "Project.Name");
            return View();
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,TaskStartDate,TaskEndDate,TaskStatusId,UserStoryId,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] ProjectTask projectTask)
        {
            AuditTable.InsertAuditFields(projectTask);
            if (ModelState.IsValid)
            {
                projectTask.Id = Guid.NewGuid();
                db.ProjectTasks.Add(projectTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted).Select(s => s), "Id", "FullName", projectTask.EmployeeId);
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted).Select(s => s), "Id", "Status", projectTask.TaskStatusId);
            ViewBag.UserStoryId = new SelectList(db.UserStories.Where(s => !s.IsDeleted).Select(s => s), "Id", "Project.Name", projectTask.UserStoryId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted).Select(s => s), "Id", "FullName", projectTask.EmployeeId);
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted).Select(s => s), "Id", "Status", projectTask.TaskStatusId);
            ViewBag.UserStoryId = new SelectList(db.UserStories.Where(s => !s.IsDeleted).Select(s => s), "Id", "Project.Name", projectTask.UserStoryId);
            return View(projectTask);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,TaskStartDate,TaskEndDate,TaskStatusId,UserStoryId,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTask).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(projectTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees.Where(s => !s.IsDeleted).Select(s => s), "Id", "FullName", projectTask.EmployeeId);
            ViewBag.TaskStatusId = new SelectList(db.TaskStatus.Where(s => !s.IsDeleted).Select(s => s), "Id", "Status", projectTask.TaskStatusId);
            ViewBag.UserStoryId = new SelectList(db.UserStories.Where(s => !s.IsDeleted).Select(s => s), "Id", "Project.Name", projectTask.UserStoryId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            projectTask.IsDeleted = true;
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
