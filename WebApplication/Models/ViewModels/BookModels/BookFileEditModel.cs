using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;

namespace WebApplication.Models.ViewModels.BookModels
{
    public class BookFileEditModel
    {
        public BookModel Book { get; set; }
        public HttpPostedFileBase Files { get; set; }
        public IEnumerable<ServiceFile> UpFiles { get; set; }
        public IEnumerable<ServiceCover> UpCovers { get; set; }
        public HttpPostedFileBase Covers { get; set; }
    }
}