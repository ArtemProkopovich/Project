using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Infrastructure.Mappers
{
    public static class QuoteMapper
    {
        public static QuoteModel ToQuoteModel(this ServiceQuote quote)
        {
            return new QuoteModel()
            {
                ID = quote.ID,
                CollectionBookID = quote.CollectionBookID,
                Text = quote.Text
            };
        }

        public static ServiceQuote ToServiceQuote(this QuoteModel quote)
        {
            return new ServiceQuote()
            {
                ID = quote.ID,
                CollectionBookID = quote.CollectionBookID,
                Text = quote.Text
            };
        }
    }
}