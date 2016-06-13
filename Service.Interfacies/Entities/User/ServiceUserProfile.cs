using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceUserProfile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
        public bool Male { get; set; }
        public DateTime BirthDate { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
    }
}
