using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalScreening:IEntity
    {
        public int ID { get; set; }
        public int BookID { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public string Link { get; set; }
    }
}
