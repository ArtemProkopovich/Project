using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmContentMapper
    {
        public static Contents ToOrmContent(this DalContent content)
        {
            return new Contents
            {
                ContentID = content.ID,
                BookID = content.BookID,
                UserID = content.UserID,
                Text = content.Text
            };
        }

        public static DalContent ToDalContent(this Contents content)
        {
            return new DalContent
            {
                ID = content.ContentID,
                BookID = content.BookID,
                UserID = content.UserID,
                Text = content.Text
            };
        }
    }
}
