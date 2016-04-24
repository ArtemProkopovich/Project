using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IUserService
    {
        ServiceUser Login(ServiceEmailAuthorizeUser user);
        ServiceUser Login(ServiceLoginAuthorizeUser user);
        ServiceUser Sign(ServiceUser user);
        ServiceUser Exit(ServiceUser user);
    }
}
