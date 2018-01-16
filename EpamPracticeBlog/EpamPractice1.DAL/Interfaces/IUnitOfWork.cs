using EpamPractice1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamPractice1.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Form> Forms { get; }
        IRepository<Appreciation> Appreciations { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Tag> Tags { get; }
        IRepository<TagArticle> TagArticles { get; }
        void Save();
    }
}
