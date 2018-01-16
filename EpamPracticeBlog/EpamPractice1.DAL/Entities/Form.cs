using System.Collections.Generic;

namespace EpamPractice1.DAL.Entities
{

    public class Form
    {
        public int FormID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Appreciation> Appreciations { get; set; }
    }
}