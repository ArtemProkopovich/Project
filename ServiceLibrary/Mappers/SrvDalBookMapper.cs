using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmBookMapper
    {
        public static ServiceBook ToServiceBook(this DalBook book)
        {
            return new ServiceBook()
            {
                ID = book.ID,
                AgeCategory = book.AgeCategory,
                FirstPublication = book.FirstPublication,
                Name = book.Name
            };
        }

        public static DalBook ToDalBook(this ServiceBook book)
        {
            return new DalBook
            {
                ID = book.ID,
                FirstPublication = book.FirstPublication,
                Name = book.Name,
                AgeCategory = book.AgeCategory
            };
        }
    }
}
