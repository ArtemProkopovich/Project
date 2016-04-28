using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmCollectionMapper
    {
        public static ServiceCollection ToServiceCollection(this DalCollection cl)
        {
            return new ServiceCollection
            {
                ID = cl.ID,
                Name = cl.Name,
                Description = cl.Description,
                UserID = cl.UserID
            };
        }

        public static DalCollection ToDalCollection(this ServiceCollection cl)
        {
            return new DalCollection
            {
                ID = cl.ID,
                Name = cl.Name,
                UserID = cl.UserID,
                Description = cl.Description
            };
        }
    }
}
