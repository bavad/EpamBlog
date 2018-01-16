using EpamPractice1.DAL.Entities;
using EpamPractice1.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EpamPractice1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public EFUnitOfWork db = new EFUnitOfWork();

        public ActionResult Index()
        {
            return View(db.Tags.GetAll().ToList());
        }

        [HttpPost]
        public ActionResult Index(string name, string body, int[] tags)
        {
            var article = new Article();
            article.Name = name;
            article.Body = body;
            article.Rating = 0;
            article.Date = DateTime.UtcNow;
            db.Articles.Create(article);
            db.Save();

            int articleId = db.Articles.GetAll().ToList().Last().ArticleID;
            TagArticle tagArticle;
            foreach (var tag in tags)
            {
                tagArticle = new TagArticle();
                tagArticle.ArticleID = articleId;
                tagArticle.TagID = tag;                
                db.TagArticles.Create(tagArticle);
                db.Save();
            }
            return RedirectToAction("Index");
        }
    }
}