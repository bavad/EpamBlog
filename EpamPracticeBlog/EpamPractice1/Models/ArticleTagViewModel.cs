using EpamPractice1.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpamPractice1.Models
{
    public class ArticleTagViewModel
    {
        public Article Article { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ArticleTagViewModel()
        {
            Tags = new List<Tag>();
        }
    }
}