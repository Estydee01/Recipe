using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeAssig.Models;

namespace RecipeAssig.Controllers
{
    public class UsersRolesController : Controller
    {
        private RecipeEntities1 db = new RecipeEntities1();

        // GET: UsersRoles
        public ActionResult Index()
        {
            var usersRoles = db.UsersRoles.Include(u => u.Role).Include(u => u.User);
            return View(usersRoles.ToList());
        }

        // GET: UsersRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersRole usersRole = db.UsersRoles.Find(id);
            if (usersRole == null)
            {
                return HttpNotFound();
            }
            return View(usersRole);
        }

        // GET: UsersRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Admin");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username");
            return View();
        }

        // POST: UsersRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,RoleId")] UsersRole usersRole)
        {
            if (ModelState.IsValid)
            {
                db.UsersRoles.Add(usersRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Admin", usersRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersRole.UserId);
            return View(usersRole);
        }

        // GET: UsersRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersRole usersRole = db.UsersRoles.Find(id);
            if (usersRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Admin", usersRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersRole.UserId);
            return View(usersRole);
        }

        // POST: UsersRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RoleId")] UsersRole usersRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "Admin", usersRole.RoleId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Username", usersRole.UserId);
            return View(usersRole);
        }

        // GET: UsersRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersRole usersRole = db.UsersRoles.Find(id);
            if (usersRole == null)
            {
                return HttpNotFound();
            }
            return View(usersRole);
        }

        // POST: UsersRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersRole usersRole = db.UsersRoles.Find(id);
            db.UsersRoles.Remove(usersRole);
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
