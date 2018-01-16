using System;
using System.Linq;
using System.Web.Mvc;
using EpamPractice1.DAL.Repositories;
using EpamPractice1.DAL.Entities;

namespace EpamPractice1.Controllers
{
    /// <summary>
    ///  ReviewsController class
    ///  reviews controller   
    /// </summary>
    [Authorize]
    public class ReviewsController : Controller
    {
        public EFUnitOfWork db = new EFUnitOfWork();

        /// <summary>
        ///  Index() metod
        ///  returns view 
        ///  with reviews
        /// </summary>
        public ActionResult Index()
        {            
            return View(db.Reviews.GetAll().ToList());
        }

        /// <summary>
        ///  Create() method
        ///  adds new review to DB,
        ///  returns view
        ///  with new review
        /// </summary>
        /// <param name="authorName">Name of the review author</param>  
        /// <param name="body">Review text</param>  
        [HttpPost]        
        public ActionResult Create(string authorName, string body)
        {
            var review = new Review();
            review.AuthorName = authorName;
            review.Date = DateTime.Now;
            review.Body = body;

            if (ModelState.IsValid)
            {
                db.Reviews.Create(review);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(review);
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
