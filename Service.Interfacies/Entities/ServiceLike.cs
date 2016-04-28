using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceLike
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int BookID { get; set; }
        public bool Like { get; set; }
    }
}
