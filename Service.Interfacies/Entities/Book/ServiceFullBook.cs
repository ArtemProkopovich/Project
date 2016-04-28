using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceFullBook
    {
        public ServiceBook BookData { get; set; }
        public IEnumerable<ServiceFile> Files { get; set; }
        public IEnumerable<ServiceCover> Covers { get; set; }
        public IEnumerable<ServiceScreening> Screeninigs { get; set; }
        public IEnumerable<ServiceGenre> Genres { get; set; }
        public IEnumerable<ServiceTag> Tags { get; set; }
        public IEnumerable<ServiceList> Lists { get; set; }
        public IEnumerable<ServiceAuthor> Authors { get; set; }
    }
}
