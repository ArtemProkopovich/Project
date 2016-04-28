using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmFileMapper
    {
        public static ServiceFile ToServiceFile(this DalFile file)
        {
            return new ServiceFile
            {
                ID = file.ID,
                BookID = file.BookID,
                Path = file.Path
            };
        }

        public static DalFile ToDalFile(this ServiceFile file)
        {
            return new DalFile
            {
                ID = file.ID,
                BookID = file.BookID,
                Path = file.Path
            };
        }
    }
}
