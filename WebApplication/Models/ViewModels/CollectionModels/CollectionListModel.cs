using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service.Interfacies.Entities;
using WebApplication.Models.Shared;

namespace WebApplication.Models.CollectionModels
{
    public class CollectionListModel : _UserProfileModel
    {
        public CollectionListModel(_UserProfileModel profile, IEnumerable<CollectionBookListModel> colectionsBooks)
        {
            ID = profile.ID;
            Name = profile.Name;
            Surname = profile.Surname;
            PhotoPath = profile.PhotoPath;
            Collections = colectionsBooks;
        }
        public CollectionListModel() { }
        public IEnumerable<CollectionBookListModel> Collections { get; set; }
    }
}