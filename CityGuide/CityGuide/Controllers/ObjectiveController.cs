using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using CG.DataAccess;
using CG.Domain;
using CityGuide.Application;

namespace CityGuide.Controllers
{
    public class ObjectiveController : Controller
    {
        private CityGuideContext ctx = new CityGuideContext();

        public ActionResult Details(int? id)
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
            review.IdUser = ctx.Users.Where(c => c.FacebookID == FacebookID.ToString()).Select(c => c.Id).First();

            if (ModelState.IsValid)
            {
                ctx.Reviews.Add(review);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
