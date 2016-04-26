using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalReview:IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public string Text { get; set; }
    }
}
