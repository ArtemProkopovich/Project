using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities.Book
{
    public class ServiceShortBook
    {
        public ServiceBook BookData { get; set; }
        public IEnumerable<ServiceCover> Covers { get; set; }
        public IEnumerable<ServiceLike> Likes { get; set; }
        public IEnumerable<ServiceAuthor> Authors { get; set; }
    }
}
