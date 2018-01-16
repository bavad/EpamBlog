using System.Linq;
using System.Web.Mvc;
using EpamPractice1.DAL.Repositories;
using EpamPractice1.DAL.Entities;

namespace EpamPractice1.Controllers
{
    /// <summary>
    ///  FormsController class
    ///  questionnaire controller   
    /// </summary>
    [Authorize]
    public class FormsController : Controller
    {
        public EFUnitOfWork db = new EFUnitOfWork();

        /// <summary>
        ///  Index() method
        ///  returns view with
        ///  questionnaire or questionnaire results
        ///  depending on the arguments    
        /// </summary>
        /// <param name="name">Name of the questioned person</param>
        /// <param name="gender">Genre of the questioned person</param>
        /// <param name="articleId">Favorite articles</param>
        [AcceptVerbs("Get", "Post")]
        public ActionResult Index(string name, string gender, int[] articleId)
        {
            if ((name != null) && (gender != null) && (articleId != null))
            {
                var form = new Form();
                form.Name = name;
                form.Gender = gender;
                Article article;
                if (ModelState.IsValid)
                {
                    db.Forms.Create(form);
                    db.Save();
                    int formId = db.Forms.GetAll().ToList().Last().FormID;
                    Appreciation appreciation;
                    foreach (var id in articleId)
                    {
                        appreciation = new Appreciation();
                        appreciation.FormID = formId;
                        appreciation.ArticleID = id;

                        article = db.Articles.Get(id);
                        appreciation.ArticleName = article.Name;
                        db.Appreciations.Create(appreciation);
                        db.Save();
                    }
                    return View("FormResult", form);
                }
                else
                {
                    return View(db.Articles.GetAll().ToList());
                }
                
            }
            else
            {
                return View(db.Articles.GetAll().ToList());
            }
            
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
