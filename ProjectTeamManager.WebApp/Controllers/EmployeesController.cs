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
    public class EmployeesController : Controller
    {
        private DBGroup1Entities db = new DBGroup1Entities();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = from s in db.Employees where !s.IsDeleted select s;
            return View(employee.ToList());
        }
        [HttpPost]
        public ActionResult Index(string search, string phone)
        {
            var Lists = from s in db.Employees where !s.IsDeleted select s;
            string searchString = StringHelpers.ConvertToUnSign(search).ToLower();
            IEnumerable<Employee> result = Lists.ToList().FindAll(
                delegate (Employee e)
                {
                    if ((StringHelpers.ConvertToUnSign(e.FirstName.ToLower()).Contains(searchString))
                            || (StringHelpers.ConvertToUnSign(e.LastName.ToLower()).Contains(searchString))
                            || (searchString.Contains(StringHelpers.ConvertToUnSign(e.FirstName.ToLower())))
                            && (searchString.Contains(StringHelpers.ConvertToUnSign(e.LastName.ToLower())))
                    )
                        return true;
                    else
                        return false;
                }
            );
            if (!String.IsNullOrEmpty(phone))
            {
                result = result.Where(s => s.ContactNo.Contains(phone));

            }
            return View(result);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ContactNo,Email,Skills,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] Employee employee)
        {
            AuditTable.InsertAuditFields(employee);
            if (ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ContactNo,Email,Skills,IsDeleted,InsAt,InsBy,UpdAt,UpdBy")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                AuditTable.UpdateAuditFields(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Employee employee = db.Employees.Find(id);
            employee.IsDeleted = true;
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
