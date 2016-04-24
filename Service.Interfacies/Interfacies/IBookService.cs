using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfacies.Entities;

namespace Service.Interfacies
{
    public interface IBookService
    {
        void AddBook(ServiceBook book);
        void RemoveBook(ServiceBook book);
        void UpdateBook(ServiceBook book);
        ServiceBook FindFirst(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> FindAll(Func<ServiceBook, bool> func);
        IEnumerable<ServiceBook> GetUserBooks(ServiceUser user);
        ServiceBook RandomBook();
        ServiceBook RandomBook(Func<ServiceBook, bool> func);
    }
}
