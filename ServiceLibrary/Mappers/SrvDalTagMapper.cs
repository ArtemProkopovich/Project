using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmTagMapper
    {
        public static ServiceTag ToServiceTag(this DalTag tag)
        {
            return new ServiceTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

        public static DalTag ToDalTag(this ServiceTag tag)
        {
            return new DalTag
            {
                ID = tag.ID,
                Name = tag.Name
            };
        }

    }
}
