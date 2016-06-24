using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Interfacies;
using Service.Interfacies.Entities;
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

        [HttpGet]
        public ActionResult UpdateLike(int bookId, bool? like, string returnUrl)
        {
            try
            {
                int userID = (int) Profile["ID"];
                var book = manager.bookService.GetBookById(bookId);
                var dbLike = manager.commentService.GetBookLikes(book).FirstOrDefault(e => e.UserID == userID);
                if (dbLike != null)
                {
                    if (like == null)
                    {
                        manager.commentService.RemoveLike(dbLike);
                    }
                    else
                    {
                        dbLike.Like = (bool)like;
                        manager.commentService.UpdateLike(dbLike);
                    }
                }
                else if(like!=null)
                {
                    manager.commentService.AddLike(new ServiceLike()
                    {
                        BookID = bookId,
                        UserID = userID,
                        Like = (bool) like
                    });
                }
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Details", "Books", new {id = bookId});
            }
            catch (Exception ex)
            {
                return View("Error");
            }
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
                return RedirectToAction("Details", "Books", new {id = comment.Book.ID});
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
                return RedirectToAction("Details", "Books", new { id = content.Book.ID });
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
                return RedirectToAction("Details", "Books", new { id = review.Book.ID });
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult DeleteComment(int id)
        {
            try
            {
                var user = manager.userService.GetUserById((int)HttpContext.Profile["ID"]);
                var comment = manager.commentService.GetUserComments(user).FirstOrDefault(e => e.UserID == user.ID);
                if (comment != null)
                {
                    manager.commentService.RemoveComment(comment);
                    return RedirectToAction("ContentDetails", "User");
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult DeleteContent(int id)
        {
            try
            {
                var user = manager.userService.GetUserById((int)HttpContext.Profile["ID"]);
                var content = manager.commentService.GetUserContents(user).FirstOrDefault(e => e.UserID == user.ID);
                if (content != null)
                {
                    manager.commentService.RemoveContent(content);
                    return RedirectToAction("ContentDetails", "User");
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult DeleteReview(int id)
        {
            var user = manager.userService.GetUserById((int)HttpContext.Profile["ID"]);
            var review = manager.commentService.GetUserReviews(user).FirstOrDefault(e => e.UserID == user.ID);
            if (review != null)
            {
                manager.commentService.RemoveReview(review);
                return RedirectToAction("ContentDetails", "User");
            }
            return RedirectToAction("Login", "Login");
        }
    }
}