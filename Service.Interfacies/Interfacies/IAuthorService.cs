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
        int AddAuthor(ServiceAuthor author);
        void RemoveAuthor(ServiceAuthor author);
        void UpdateAuthor(ServiceAuthor author);
        ServiceAuthor GetById(int id);
        ServiceAuthor GetByName(string name);
        int GetAuthorsCount();
        IEnumerable<ServiceAuthor> GetAllAuthors();
        IEnumerable<ServiceAuthor> OrderTake(int offset, int count);
        ServiceFullAuthor GetFullAuthorInfo(int id);
        ServiceFullAuthor GetFullAuthorInfo(ServiceAuthor author);
        void AddAuthorBook(ServiceAuthor author, ServiceBook book);
        void RemoveAuthorBook(ServiceAuthor author, ServiceBook book);
        ServiceAuthor FindFirst(Func<ServiceAuthor, bool> func);
        IEnumerable<ServiceAuthor> FindAll(Func<ServiceAuthor, bool> func);

    }
}
