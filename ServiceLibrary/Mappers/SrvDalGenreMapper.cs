using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmGenreMapper
    {
        public static ServiceGenre ToServiceGenre(this DalGenre genre)
        {
            return new ServiceGenre
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }

        public static DalGenre ToDalGenre(this ServiceGenre genre)
        {
            return new DalGenre
            {
                ID = genre.ID,
                Name = genre.Name
            };
        }
    }
}
