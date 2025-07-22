using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using techinsight.Models;

namespace techinsight.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string technology = "")
        {
            var articles = db.Articles.AsQueryable();
            
            // Filter by technology if specified
            if (!string.IsNullOrEmpty(technology))
            {
                articles = articles.Where(a => a.Technology == technology);
            }
            
            // Get list of unique technologies for dropdown
            ViewBag.Technologies = db.Articles.Select(a => a.Technology).Distinct().ToList();
            ViewBag.SelectedTechnology = technology;
            
            return View(articles.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
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