using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmListMapper
    {
        public static ServiceList ToServiceList(this DalList list)
        {
            return new ServiceList
            {
                ID = list.ID,
                Name = list.Name
            };
        }

        public static DalList ToDalList(this ServiceList list)
        {
            return new DalList
            {
                ID = list.ID,
                Name = list.Name
            };
        }
    }
}
