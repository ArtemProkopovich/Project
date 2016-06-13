using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalUserProfile : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Male { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoPath { get; set; }
        public int Points { get; set; }
        public int Level { get; set; }
    }
}
