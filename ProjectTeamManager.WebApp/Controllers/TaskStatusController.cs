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
    public class TaskStatusController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();
        // GET: TaskStatus
        public ActionResult Index()
        {
            var taskStatus = from s in db.TaskStatus
                             where !s.IsDeleted
                             select s;
            return View(taskStatus.ToList());
        }
        [HttpPost]
        public ActionResult Index(Guid? projectId, string search)
        {
            var taskStatus = from s in db.TaskStatus
                             where !s.IsDeleted
                             select s;
            string searchString = StringHelpers.ConvertToUnSign(search).ToLower();
            IEnumerable<TaskStatu> result = taskStatus.ToList().FindAll(
                delegate (TaskStatu tS)
                {
                    if (StringHelpers.ConvertToUnSign(tS.Status.ToLower()).Contains(searchString))
                        return true;
                    else
                        return false;
                }
            );
            return View(result);
        }

        // GET: TaskStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status,Description,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] TaskStatu taskStatu)
        {
            AuditTable.InsertAuditFields(taskStatu);
            if (ModelState.IsValid)
            {
                taskStatu.Id = Guid.NewGuid();
                db.TaskStatus.Add(taskStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskStatu);
        }

        // GET: TaskStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskStatu taskStatu = db.TaskStatus.Find(id);
            if (taskStatu == null)
            {
                return HttpNotFound();
            }
            return View(taskStatu);
        }

        // POST: TaskStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status,Description,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] TaskStatu taskStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskStatu).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(taskStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskStatu);
        }

        // GET: TaskStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskStatu taskStatu = db.TaskStatus.Find(id);
            if (taskStatu == null)
            {
                return HttpNotFound();
            }
            return View(taskStatu);
        }

        // POST: TaskStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TaskStatu taskStatu = db.TaskStatus.Find(id);
            taskStatu.IsDeleted = true;
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
