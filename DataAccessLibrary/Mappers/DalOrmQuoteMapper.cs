using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfacies.Entities;
using ORMLibrary;

namespace DataAccessLibrary.Mappers
{
    public static class DalOrmQuoteMapper
    {
        public static Quotes ToOrmQuote(this DalQuote quote)
        {
            return new Quotes
            {
                QuoteID = quote.ID,
                Collection_BookID = quote.CollectionBookID,
                Text = quote.Text
            };
        }

        public static DalQuote ToDalQuote(this Quotes quote)
        {
            return new DalQuote
            {
                ID = quote.QuoteID,
                CollectionBookID = quote.Collection_BookID,
                Text = quote.Text
            };
        }
    }
}
