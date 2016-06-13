using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfacies.Entities
{
    public class ServiceUser
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<ServiceRole> Roles { get; set; }
    }
}
