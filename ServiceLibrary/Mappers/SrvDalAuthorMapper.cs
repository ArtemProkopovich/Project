using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmAuthorMapper
    {
        public static DalAuthor ToDalAuthor(this ServiceAuthor author)
        {
            return new DalAuthor()
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Biography = author.Biography
            };
        }

        public static ServiceAuthor ToServiceAuthor(this DalAuthor author)
        {
            return new ServiceAuthor()
            {
                ID = author.ID,
                Name = author.Name,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Biography = author.Biography
            };
        }
    }
}
