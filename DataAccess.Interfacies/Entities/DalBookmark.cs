using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalBookmark:IEntity
    {
        public int ID { get; set; }
        public int CollectionBookID { get; set; }
        public int Page { get; set; }
    }
}
