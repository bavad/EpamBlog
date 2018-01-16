using System;
using System.Collections.Generic;

namespace EpamPractice1.DAL.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public string BodyPreview
        {
            get {
                if (Body.Length < 200)
                {
                    return Body + "...";
                }
                return Body.Substring(0, 200) + "...";
            }
        }

        public virtual ICollection<Appreciation> Appreciations { get; set; }
        public virtual ICollection<TagArticle> TagArticles { get; set; }

    }
}
