﻿using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CG.DataAccess;
using CG.Domain;
using CityGuide.Application;
using CityGuide.ViewModels;
using System.Data.Entity;

namespace CityGuide.Controllers
{
    public class ObjectiveController : Controller
    {
        private CityGuideContext ctx = new CityGuideContext();
        private ObjectivesWorkerService _objWorkerSvc;

        public ObjectiveController(ObjectivesWorkerService objService)
        {
            _objWorkerSvc = objService;
        }
        public ActionResult Details(int id)
        {
            ObjectiveViewModel objective = _objWorkerSvc.GetObjectiveByID(id);

            if (objective == null)
            {
                return HttpNotFound();
            }

            return View(objective);
        }

        [Authorize]
        public ActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddReview(Review review, int ObjectiveId)
        {
            var FacebookID = Session["FacebookID"].ToString();

            review.Objective = ctx.Objectives.Where(c => c.Id == ObjectiveId).First();
            review.User = ctx.Users.Where(c => c.FacebookID == FacebookID.ToString()).First();

            if (ModelState.IsValid)
            {
                ctx.Reviews.Add(review);
                ctx.SaveChanges();
                return RedirectToAction("Details/" + ObjectiveId, "Objective");
            }

            return View();
        }

        [AdminAuthorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective obj = ctx.Objectives.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objective obj = ctx.Objectives.Find(id);
            ctx.Objectives.Remove(obj);
            ctx.SaveChanges();
            return RedirectToAction("Details/" + obj.Category, "Category", null);
        }

        [AdminAuthorize]
        public ActionResult DeleteReview(int id)
        {
            Review rev = ctx.Reviews.Find(id);
            ctx.Reviews.Remove(rev);
            ctx.SaveChanges();
            return RedirectToAction("Details/" + rev.Objective, "Objective", null);
        }

        [AdminAuthorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objective objective = ctx.Objectives.Find(id);
            if (objective == null)
            {
                return HttpNotFound();
            }
            return View(objective);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Name,Score,Category,Address,Photos")] Objective objective)
        {
            if (ModelState.IsValid)
            {
                ctx.Entry(objective).State = EntityState.Modified;
                foreach(var p in objective.Photos)
                {
                    ctx.Entry(p).State = EntityState.Modified;
                }
                ctx.SaveChanges();
                return RedirectToAction("Details/" + objective.Category, "Category", null);
            }
            return View(objective);
        }
    }
}
