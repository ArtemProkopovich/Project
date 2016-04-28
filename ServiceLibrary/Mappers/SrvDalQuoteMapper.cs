using DataAccess.Interfacies.Entities;
using Service.Interfacies.Entities;

namespace ServiceLibrary.Mappers
{
    public static class DalOrmQuoteMapper
    {
        public static ServiceQuote ToServiceQuote(this DalQuote quote)
        {
            return new ServiceQuote
            {
                ID = quote.ID,
                CollectionBookID = quote.CollectionBookID,
                Text = quote.Text
            };
        }

        public static DalQuote ToDalQuote(this ServiceQuote quote)
        {
            return new DalQuote
            {
                ID = quote.ID,
                CollectionBookID = quote.CollectionBookID,
                Text = quote.Text
            };
        }
    }
}
