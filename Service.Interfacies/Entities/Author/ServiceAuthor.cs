using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceAuthor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Biography { get; set; }
        public string Photo { get; set; }
    }
}
