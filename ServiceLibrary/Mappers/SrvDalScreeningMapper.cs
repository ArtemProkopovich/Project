using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmScreeningMapper
    {
        public static ServiceScreening ToServiceScreening(this DalScreening screening)
        {
            return new ServiceScreening
            {
                ID = screening.ID,
                BookID = screening.BookID,
                Link = screening.Link,
                Name = screening.Name,
                Year = screening.Year
            };
        }

        public static DalScreening ToDalScreening(this ServiceScreening screening)
        {
            return new DalScreening
            {
                ID = screening.ID,
                BookID = screening.BookID,
                Link = screening.Link,
                Name = screening.Name,
                Year = screening.Year
            };
        }
    }
}
