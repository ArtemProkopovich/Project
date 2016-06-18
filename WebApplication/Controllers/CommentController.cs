using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using WebApplication.Models.ContentModels;
using WebApplication.Models.DataModels;
using WebApplication.Models.UserModels;

namespace WebApplication.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IServiceManager manager;
        public CommentController(IServiceManager manager)
        {
            this.manager = manager;
        }

        // GET: Comment
        [HttpPost]
        public ActionResult CreateComment(CommentModel comment)
        {
            try
            {
                comment.User = new UserShortModel();
                comment.User.ID = (int)HttpContext.Profile["ID"];
                comment.PublishTime = DateTime.Now;
                var serviceComment = Comment.GetServiceComment(comment);
                manager.commentService.AddComment(serviceComment);
                return RedirectToAction("Details", "Books", new {id = comment.BookID});
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult CreateContent(ContentModel content)
        {
            try
            {
                content.User = new UserShortModel();
                content.User.ID = (int)HttpContext.Profile["ID"];
                var serviceContent = Models.DataModels.Content.GetServiceContent(content);
                manager.commentService.AddContent(serviceContent);
                return RedirectToAction("Details", "Books", new { id = content.BookID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult CreateReview(ReviewModel review)
        {
            try
            {
                review.User = new UserShortModel();
                review.User.ID = (int)HttpContext.Profile["ID"];
                review.PublishTime = DateTime.Now;
                var serviceReview = Review.GetServiceReview(review);
                manager.commentService.AddReview(serviceReview);
                return RedirectToAction("Details", "Books", new { id = review.BookID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

    }
}