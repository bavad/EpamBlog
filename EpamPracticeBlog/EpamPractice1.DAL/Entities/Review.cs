using System;

namespace EpamPractice1.DAL.Entities
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string AuthorName { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
    }
}