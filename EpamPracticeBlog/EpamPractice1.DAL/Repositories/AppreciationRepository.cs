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
    class AppreciationRepository : IRepository<Appreciation>
    {
        private BlogContext db;

        public AppreciationRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Appreciation> GetAll()
        {
            return db.Appreciations;
        }

        public Appreciation Get(int id)
        {
            return db.Appreciations.Find(id);
        }

        public void Create(Appreciation appreciation)
        {
            db.Appreciations.Add(appreciation);
        }

        public void Update(Appreciation appreciation)
        {
            db.Entry(appreciation).State = EntityState.Modified;
        }

        public IEnumerable<Appreciation> Find(Func<Appreciation, Boolean> predicate)
        {
            return db.Appreciations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Appreciation appreciation = db.Appreciations.Find(id);
            if (appreciation != null)
                db.Appreciations.Remove(appreciation);
        }
    }
}
