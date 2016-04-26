using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmFileMapper
    {
        public static Files ToOrmFile(this DalFile file)
        {
            return new Files
            {
                FileID = file.ID,
                BookID = file.BookID,
                Path = file.Path
            };
        }

        public static DalFile ToDalFile(this Files file)
        {
            return new DalFile
            {
                ID = file.FileID,
                BookID = file.BookID,
                Path = file.Path
            };
        }
    }
}
