using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.ContentModels;

namespace WebApplication.Models.DataModels
{
    public class Quote
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static QuoteModel GetQuoteModel(ServiceQuote quote)
        {
            return quote.ToQuoteModel();
        }

        public static IEnumerable<QuoteModel> GetQuoteList(int id)
        {
            var cb= manager.collectionService.GetCollectionBookById(id);
            return manager.collectionService.GetQuotes(cb).Select(GetQuoteModel);
        }
    }
}