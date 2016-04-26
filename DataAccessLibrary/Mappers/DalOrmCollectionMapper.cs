using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmCollectionMapper
    {
        public static Collections ToOrmCollection(this DalCollection cl)
        {
            return new Collections
            {
                CollectionID = cl.ID,
                Name = cl.Name,
                Description = cl.Description,
                UserID = cl.UserID
            };
        }

        public static DalCollection ToDalCollection(this Collections cl)
        {
            return new DalCollection
            {
                ID = cl.CollectionID,
                Name = cl.Name,
                UserID = cl.UserID,
                Description = cl.Description
            };
        }
    }
}
