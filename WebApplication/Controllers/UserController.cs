using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using Service.Interfacies;
using Service.Interfacies.Entities;
using WebApplication.Infrastructure;
using WebApplication.Infrastructure.Mappers;
using WebApplication.Models.UserModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            try
            {
                int id = (int)HttpContext.Profile["ID"];
                return View(Models.DataModels.User.GetUserIndexModel(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult ContentDetails()
        {
            try
            {
                int id = (int)HttpContext.Profile["ID"];
                return View(Models.DataModels.User.GetUserContentDetailsModel(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit()
        {
            try
            {
                int id = (int)HttpContext.Profile["ID"];
                return View(Models.DataModels.User.GetUserProfileModel(id));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(UserProfileModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.NewPhoto != null)
                    {
                        string filepath = Server.MapPath("~/App_Data/Uploads/Covers/Users/" +
                                                         FilePathGenerator.GenerateFileName(model.NewPhoto.FileName));
                        if (!string.IsNullOrEmpty(model.PhotoPath) && System.IO.File.Exists(model.PhotoPath))
                            System.IO.File.Delete(model.PhotoPath);
                        model.NewPhoto.SaveAs(filepath);
                        model.PhotoPath = filepath;

                    }
                    userService.UpdateUserProfile(model.ToServiceUserProfile());
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        [AllowAnonymous]
        public FileResult GetImage(int id)
        {
            try
            {
                var profile = userService.GetUserProfile(id) ?? new ServiceUserProfile() {ID = id};
                return !string.IsNullOrEmpty(profile.PhotoPath)
                    ? new FilePathResult(profile.PhotoPath, "image/*")
                    : new FilePathResult(Server.MapPath("~/App_Data/Uploads/Covers/Users/" + "no_user_cover.png"),
                        "image/*");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return null;
            }
        }
    }
}