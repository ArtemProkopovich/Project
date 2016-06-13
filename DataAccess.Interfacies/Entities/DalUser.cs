using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfacies.Entities
{
    public class DalUser : IEntity
    {
        public int ID { get; set; }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
