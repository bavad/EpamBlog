using System.Linq;
using System.Web.Mvc;
using EpamPractice1.DAL.Repositories;
using EpamPractice1.DAL.Entities;
using System.Net;
using EpamPractice1.Models;
using EpamPractice1.DAL.EF;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace EpamPractice1.Controllers
{
    /// <summary>
    ///  ArticlesController class
    ///  articles controller   
    /// </summary>
    [Authorize]
    public class ArticlesController : Controller
    {
        public EFUnitOfWork db = new EFUnitOfWork();
       
        bool IsAdmin()
        {
            var isAdmin = false;

            IList<string> roles = new List<string>();
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            if (roles.Contains("Admin"))
            {
                isAdmin = true;
            }
            return isAdmin;
        }
        
        /// <summary>
        ///  Index() method
        ///  returns view
        ///  with articles
        /// </summary>    
        [HttpGet]
        public ActionResult Index()
        {
            //var isAdmin = false;

            //IList<string> roles = new List<string>();
            //ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            //if (user != null)
            //    roles = userManager.GetRoles(user.Id);
            //if (roles.Contains("Admin"))
            //{
            //    isAdmin = true;
            //}

            ViewBag.Admin = IsAdmin();

            return View(db.Articles.GetAll().ToList());                 
        }
        
        [HttpPost]        
        public ActionResult Index(int articleId)
        {
            Article art = new Article();
            art = db.Articles.Get(articleId);
            art.Rating++;
            db.Articles.Update(art);
            db.Save();
            ViewBag.Admin = IsAdmin();
            return View(db.Articles.GetAll().ToList());
        }

        /// <summary>
        ///  Create() method
        ///  returns view
        ///  for creating the new article
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        ///  Create() method
        ///  adds new article to DB,
        ///  returns view with
        ///  the new article
        /// </summary>
        /// <param name="article">New article object</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArticleID,Name,Date,Body")] Article article)
        {
            
            if (ModelState.IsValid)
            {
                db.Articles.Create(article);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        /// <summary>
        ///  ArticleInfo() method
        ///  returns view of 
        ///  the article with tags
        /// </summary>
        /// <param name="id">Article Id</param>
        public ActionResult ArticleInfo(int id)
        {            
            Article article = db.Articles.Get(id);
            ArticleTagViewModel articleTag = new ArticleTagViewModel();
            articleTag.Article = article;
            
            Tag tag;
            foreach(var t in article.TagArticles)
            {
                tag = db.Tags.Get(t.TagID);
                articleTag.Tags.Add(tag);
            }
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(articleTag);
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
