using EpamPractice1.DAL.EF;
using EpamPractice1.DAL.Entities;
using EpamPractice1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamPractice1.DAL.Repositories
{
    class TagArticleRepository : IRepository<TagArticle>
    {
        private BlogContext db;

        public TagArticleRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<TagArticle> GetAll()
        {
            return db.TagArticles;
        }

        public TagArticle Get(int id)
        {
            return db.TagArticles.Find(id);
        }

        public void Create(TagArticle tagArticle)
        {
            db.TagArticles.Add(tagArticle);
        }

        public void Update(TagArticle tagArticle)
        {
            db.Entry(tagArticle).State = EntityState.Modified;
        }

        public IEnumerable<TagArticle> Find(Func<TagArticle, Boolean> predicate)
        {
            return db.TagArticles.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TagArticle tagArticle = db.TagArticles.Find(id);
            if (tagArticle != null)
                db.TagArticles.Remove(tagArticle);
        }
    }
}
