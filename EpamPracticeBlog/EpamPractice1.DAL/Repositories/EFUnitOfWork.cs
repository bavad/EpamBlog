using EpamPractice1.DAL.EF;
using EpamPractice1.DAL.Entities;
using EpamPractice1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamPractice1.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private BlogContext db;
        private ArticleRepository articleRepository;
        private FormRepository formRepository;
        private AppreciationRepository appreciationRepository;
        private ReviewRepository reviewRepository;
        private TagRepository tagRepository;
        private TagArticleRepository tagArticleRepository;


        public EFUnitOfWork()
        {
            db = new BlogContext();
        }
        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public IRepository<Form> Forms
        {
            get
            {
                if (formRepository == null)
                    formRepository = new FormRepository(db);
                return formRepository;
            }
        }

        public IRepository<Appreciation> Appreciations
        {
            get
            {
                if (appreciationRepository == null)
                    appreciationRepository = new AppreciationRepository(db);
                return appreciationRepository;
            }
        }

        public IRepository<Review> Reviews
        {
            get
            {
                if (reviewRepository == null)
                    reviewRepository = new ReviewRepository(db);
                return reviewRepository;
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                if (tagRepository == null)
                    tagRepository = new TagRepository(db);
                return tagRepository;
            }
        }

        public IRepository<TagArticle> TagArticles
        {
            get
            {
                if (tagArticleRepository == null)
                    tagArticleRepository = new TagArticleRepository(db);
                return tagArticleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
