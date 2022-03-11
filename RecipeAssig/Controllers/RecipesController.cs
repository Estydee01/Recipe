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
    public class RecipesController : Controller
    {
        private RecipeEntities1 db = new RecipeEntities1();

        // GET: Recipes
        public ActionResult Index()
        {
          /*  var RecipeCat = new List<RecipeCat>
            {
                new RecipeCat {"vegetarian" },
                new RecipeCat{ "non_Vegetarian"}
            };*/


            var recipes = db.Recipes.Include(r => r.Rate).Include(r => r.UserProfile);
            return View(recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Rates, "Id", "Id");
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Firstname");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserProfileId,RecipeCat,Description")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Rates, "Id", "Id", recipe.Id);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Firstname", recipe.UserProfileId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Rates, "Id", "Id", recipe.Id);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Firstname", recipe.UserProfileId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserProfileId,RecipeCat,Description")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Rates, "Id", "Id", recipe.Id);
            ViewBag.UserProfileId = new SelectList(db.UserProfiles, "Id", "Firstname", recipe.UserProfileId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
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
