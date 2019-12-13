using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _1611061593_lab3.Models;

namespace _1611061593_lab3.Controllers
{
    public class View_ArticleController : Controller
    {
        private ThucHanhTMDTEntities db = new ThucHanhTMDTEntities();

        // GET: View_Article
        public ActionResult Index()
        {
            return View(db.View_Article.ToList());
        }

        // GET: View_Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            View_Article view_Article = db.View_Article.Find(id);
            if (view_Article == null)
            {
                return HttpNotFound();
            }
            return View(view_Article);
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
