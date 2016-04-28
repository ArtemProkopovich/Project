using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceQuote
    {
        public int ID { get; set; }
        public int CollectionBookID { get; set; }
        public string Text { get; set; }
    }
}
