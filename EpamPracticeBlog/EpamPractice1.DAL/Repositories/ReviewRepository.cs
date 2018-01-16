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
    class ReviewRepository : IRepository<Review>
    {
        private BlogContext db;

        public ReviewRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Review> GetAll()
        {
            return db.Reviews;
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public void Create(Review review)
        {
            db.Reviews.Add(review);
        }

        public void Update(Review review)
        {
            db.Entry(review).State = EntityState.Modified;
        }

        public IEnumerable<Review> Find(Func<Review, Boolean> predicate)
        {
            return db.Reviews.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
                db.Reviews.Remove(review);
        }
    }
}
