using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmCoverMapper
    {
        public static Covers ToOrmCover(this DalCover cover)
        {
            return new Covers
            {
                CoverID = cover.ID,
                BookID = cover.BookID,
                Image = cover.Image
            };
        }

        public static DalCover ToDalCover(this Covers cover)
        {
            return new DalCover
            {
                ID = cover.CoverID,
                BookID = cover.BookID,
                Image = cover.Image
            };
        }
    }
}
