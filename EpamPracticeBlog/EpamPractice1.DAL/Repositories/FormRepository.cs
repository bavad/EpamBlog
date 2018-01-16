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
    class FormRepository : IRepository<Form>
    {
        private BlogContext db;

        public FormRepository(BlogContext context)
        {
            this.db = context;
        }

        public IEnumerable<Form> GetAll()
        {
            return db.Forms;
        }

        public Form Get(int id)
        {
            return db.Forms.Find(id);
        }

        public void Create(Form Form)
        {
            db.Forms.Add(Form);
        }

        public void Update(Form form)
        {
            db.Entry(form).State = EntityState.Modified;
        }

        public IEnumerable<Form> Find(Func<Form, Boolean> predicate)
        {
            return db.Forms.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Form form = db.Forms.Find(id);
            if (form != null)
                db.Forms.Remove(form);
        }
    }
}
