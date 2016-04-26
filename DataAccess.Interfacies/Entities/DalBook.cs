using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalBook : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? FirstPublication { get; set; }
        public int AgeCategory { get; set; }
    }
}
