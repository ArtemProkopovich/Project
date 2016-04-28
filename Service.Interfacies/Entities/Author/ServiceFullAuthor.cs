using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceFullAuthor
    {
        public ServiceAuthor AuthorData { get; set; }
        public IEnumerable<ServiceBook> AuthorBooks { get; set; }
    }
}
