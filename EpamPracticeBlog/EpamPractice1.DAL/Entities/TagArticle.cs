using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamPractice1.DAL.Entities
{
    public class TagArticle
    {
        public int TagArticleID { get; set; }
        public int ArticleID { get; set; }
        public int TagID { get; set; }       

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
