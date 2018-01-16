namespace EpamPractice1.DAL.Entities
{
    public class Appreciation
    {
        public int AppreciationID { get; set; }
        public int ArticleID { get; set; }
        public int FormID { get; set; }
        public string ArticleName { get; set; }

        public virtual Article Article { get; set; }
        public virtual Form Form { get; set; }
    }
}