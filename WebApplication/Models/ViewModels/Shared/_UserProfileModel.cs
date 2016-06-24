using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models.Shared
{
    public class _UserProfileModel
    {
        public _UserProfileModel() { }

        public _UserProfileModel(_UserProfileModel profile)
        {
            ID = profile.ID;
            Name = profile.Name;
            Surname = profile.Surname;
            PhotoPath = profile.PhotoPath;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoPath { get; set; }
    }
}