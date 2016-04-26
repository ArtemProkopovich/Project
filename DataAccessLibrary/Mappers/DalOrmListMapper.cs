using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmListMapper
    {
        public static Lists ToOrmList(this DalList list)
        {
            return new Lists
            {
                ListID = list.ID,
                Name = list.Name
            };
        }

        public static DalList ToDalList(this Lists list)
        {
            return new DalList
            {
                ID = list.ListID,
                Name = list.Name
            };
        }
    }
}
