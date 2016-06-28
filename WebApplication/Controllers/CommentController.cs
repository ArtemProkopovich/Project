using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
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
        private Logger logger = LogManager.GetCurrentClassLogger();
        public CommentController(IServiceManager manager)
        {
            this.manager = manager;
        }

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
                        manager.commentService.RemoveLike(dbLike);
                        dbLike.ID = 0;
                        dbLike.Like = (bool)like;
                        manager.commentService.AddLike(dbLike);
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
                
                if (Request.IsAjaxRequest())
                {
                    if (returnUrl != null && returnUrl == "details")
                    {
                        return PartialView("_LikeProgressButtonsView", Like.GetLikeButtonsModel(bookId, userID));
                    }
                    return PartialView("_LikeButtonsView", Like.GetLikeButtonsModel(bookId, userID));
                }
                else
                {
                    returnUrl = returnUrl ?? "";
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Details", "Books", new {id = bookId});
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_CommentListView", Comment.GetCommentModels(comment.Book.ID));
                }
                return RedirectToAction("Details", "Books", new {id = comment.Book.ID});
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ContentListView", Models.DataModels.Content.GetContentModels(content.Book.ID));
                }
                return RedirectToAction("Details", "Books", new { id = content.Book.ID });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
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
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_ReviewListView", Review.GetReviewModels(review.Book.ID));
                }
                return RedirectToAction("Details", "Books", new { id = review.Book.ID });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult DeleteComment(int id)
        {
            try
            {
                var user = manager.userService.GetUserById((int)HttpContext.Profile["ID"]);
                var comment = manager.commentService.GetUserComments(user).FirstOrDefault(e => e.ID == id);
                if (comment != null)
                {
                    manager.commentService.RemoveComment(comment);
                    return RedirectToAction("ContentDetails", "User");
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult DeleteContent(int id)
        {
            try
            {
                var user = manager.userService.GetUserById((int)HttpContext.Profile["ID"]);
                var content = manager.commentService.GetUserContents(user).FirstOrDefault(e => e.ID == id);
                if (content != null)
                {
                    manager.commentService.RemoveContent(content);
                    return RedirectToAction("ContentDetails", "User");
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }

        public ActionResult DeleteReview(int id)
        {
            try
            {
                var user = manager.userService.GetUserById((int) HttpContext.Profile["ID"]);
                var review = manager.commentService.GetUserReviews(user).FirstOrDefault(e => e.ID == id);
                if (review != null)
                {
                    manager.commentService.RemoveReview(review);
                    return RedirectToAction("ContentDetails", "User");
                }
                return RedirectToAction("Login", "Login");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return View("Error");
            }
        }
    }
}