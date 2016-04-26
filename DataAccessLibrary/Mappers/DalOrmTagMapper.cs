using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmTagMapper
    {
        public static Tags ToOrmTag(this DalTag tag)
        {
            return new Tags
            {
                TagID = tag.ID,
                Name = tag.Name
            };
        }

        public static DalTag ToDalTag(this Tags tag)
        {
            return new DalTag
            {
                ID = tag.TagID,
                Name = tag.Name
            };
        }

    }
}
