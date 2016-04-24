using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface ICollectionService
    {
        void AddBook(ServiceCollection collection, ServiceBook book);
        void RemoveBook(ServiceCollection collection, ServiceBook book);
        IEnumerable<ServiceCollection> GetUserCollections(ServiceUser user);
        IEnumerable<ServiceCollection> FindAll(Func<ServiceCollection, bool> func);
    }
}
