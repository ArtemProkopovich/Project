using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmContentMapper
    {
        public static ServiceContent ToServiceContent(this DalContent content)
        {
            return new ServiceContent
            {
                ID = content.ID,
                BookID = content.BookID,
                UserID = content.UserID,
                Text = content.Text
            };
        }

        public static DalContent ToDalContent(this ServiceContent content)
        {
            return new DalContent
            {
                ID = content.ID,
                BookID = content.BookID,
                UserID = content.UserID,
                Text = content.Text
            };
        }
    }
}
