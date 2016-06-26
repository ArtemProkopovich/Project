using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.ViewModels.TagModels;

namespace WebApplication.Models.DataModels
{
    public class Tag
    {
        private static readonly IServiceManager manager = DependencyResolver.Current.GetService<IServiceManager>();
        public static TagModel GetTagModel(int id)
        {
            var tag = manager.listService.GetTagById(id);
            return GetTagModel(tag);
        }

        public static TagModel GetTagModel(ServiceTag tag)
        {
            return tag.ToTagModel(manager.listService.GetTagBooks(tag).Count());
        }

        public static TagIndexModel GetTagIndexModel()
        {
            TagIndexModel model = new TagIndexModel();
            model.Tags = manager.listService.GetAllTags().OrderBy(e=>e.Name).Select(GetTagModel);
            return model;
        }
    }
}