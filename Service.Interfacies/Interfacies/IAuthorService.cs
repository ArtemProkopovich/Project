using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IAuthorService
    {
        void AddAuthor(ServiceAuthor author);
        void RemoveAuthor(ServiceAuthor author);
        void UpdateAuthor(ServiceAuthor author);
        void AddBook(ServiceAuthor author, ServiceBook book);
        void RemoveBook(ServiceAuthor author, ServiceBook book);
        ServiceAuthor FindFirst(Func<ServiceAuthor, bool> func);
        IEnumerable<ServiceAuthor> FindAll(Func<ServiceAuthor, bool> func);

    }
}
