using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmCollectionBookMapper
    {
        public static ServiceCollectionBook ToServiceCollectionBook(this DalCollectionBook cb)
        {
            return new ServiceCollectionBook
            {
                ID = cb.ID,
                CollectionID = cb.CollectionID,
                BookID = cb.BookID,
                IsRead = cb.IsRead
            };
        }

        public static DalCollectionBook ToDalCollectionBook(this ServiceCollectionBook cb)
        {
            return new DalCollectionBook
            {
                ID = cb.ID,
                BookID = cb.BookID,
                CollectionID = cb.CollectionID,
                IsRead = cb.IsRead
            };
        }
    }
}
