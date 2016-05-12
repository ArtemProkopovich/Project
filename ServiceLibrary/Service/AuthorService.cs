using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies;
using DataAccess.Interfacies.Entities;
using Service.Interfacies;
using Service.Interfacies.Entities;
using ServiceLibrary.Mappers;

namespace ServiceLibrary.Service
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unit;
        public AuthorService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public void AddAuthor(ServiceAuthor author)
        {
            unit.Authors.Create(author.ToDalAuthor());
            unit.Save();
        }

        public void AddAuthorBook(ServiceAuthor author, ServiceBook book)
        {
            unit.Books.AddAuthor(book.ToDalBook(), author.ToDalAuthor());
            unit.Save();
        }

        public IEnumerable<ServiceAuthor> FindAll(Func<ServiceAuthor, bool> func)
        {
            throw new NotImplementedException();
        }

        public ServiceAuthor FindFirst(Func<ServiceAuthor, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServiceAuthor> GetAllAuthors()
        {
            return unit.Authors.GetAll().Select(e => e.ToServiceAuthor());
        }

        public ServiceAuthor GetById(int id)
        {
            return unit.Authors.GetById(id).ToServiceAuthor();
        }

        public ServiceAuthor GetByName(string name)
        {
            return unit.Authors.GetByName(name).ToServiceAuthor();
        }

        public ServiceFullAuthor GetFullAuthorInfo(ServiceAuthor author)
        {
            ServiceFullAuthor fullAuthor = new ServiceFullAuthor();
            fullAuthor.AuthorData = author;
            fullAuthor.AuthorBooks = unit.Authors.GetBooks(author.ToDalAuthor()).Select(e => e.ToServiceBook());
            return fullAuthor;
        }

        public ServiceFullAuthor GetFullAuthorInfo(int id)
        {
            ServiceFullAuthor fullAuthor = new ServiceFullAuthor();
            DalAuthor dalAuthor = unit.Authors.GetById(id);
            if (dalAuthor != null)
            {
                fullAuthor.AuthorData = dalAuthor.ToServiceAuthor();
                fullAuthor.AuthorBooks = unit.Authors.GetBooks(dalAuthor).Select(e => e.ToServiceBook());
                return fullAuthor;
            }
            return null;
        }

        public void RemoveAuthor(ServiceAuthor author)
        {
            unit.Authors.Delete(author.ToDalAuthor());
            unit.Save();
        }

        public void RemoveAuthorBook(ServiceAuthor author, ServiceBook book)
        {
            unit.Books.DeleteAuthor(book.ToDalBook(), author.ToDalAuthor());
            unit.Save();
        }

        public void UpdateAuthor(ServiceAuthor author)
        {
            unit.Authors.Update(author.ToDalAuthor());
            unit.Save();
        }
    }
}
