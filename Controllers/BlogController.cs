using _1611061593_lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _1611061593_lab3.Common;
using System.ServiceModel.Syndication;

namespace _1611061593_lab3.Controllers
{
   
    public class BlogController : Controller
    {
        ThucHanhTMDTEntities db = new ThucHanhTMDTEntities();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostFeed(string type)
        {
            Category category = db.View_Category.Where(s => s.Alias.Contains(type)).FirstOrDefault();
            if(category == null)
            {
                return HttpNotFound();
            }
            IEnumerable<View_Article> posts = (from s in db.View_Article where s.Alias.Contains(type) select s).ToList();

            var feed = new SyndicationFeed(category.Name, "RSS Feed",
                       new Uri("https://vnexpress.net/RSS"),
                       Guid.NewGuid().ToString(),
                       DateTime.Now);
            var items = new List<SyndicationItem>();
            foreach (Article art in posts)
            {
                string postUri = String.Format("https://vnexpress.net/" + art.Alias + "-{0}", art.Id);
                var item =
                    new SyndicationItem(Helper.RemoveIllegalCharacters(art.Title),
                                        Helper.RemoveIllegalCharacters(art.Description),
                                        new Uri(postUri),
                                        art.Id.ToString(),
                                        art.PublishedDate.Value);
                items.Add(item);
            }
            feed.Items = items;
            return new RSSActionResult { Feed = feed }
        }
    }
}