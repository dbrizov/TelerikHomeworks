using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AspNetMvcExam.Web.Models;
using AspNetMvcExam.Models;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.UI;
using System.Net;
using System.Collections.Generic;

namespace AspNetMvcExam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public TicketsController()
            : base()
        {
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var ticket = this.data.Tickets.All()
                .Include(t => t.Author)
                .Include(t => t.Category)
                .Include(t => t.Comments)
                .Where(t => t.Id == id)
                .Select(TicketDetailsViewModel.FromTicket.Compile())
                .FirstOrDefault();

            return View(ticket);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            //ViewBag.Categories = new SelectList(this.data.Categories.All(), "Id", "Name");
            ViewBag.Categories = this.data.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CreateTicketModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();

                var user = this.data.Users.GetById(userId);
                user.Points += 1;
                this.data.Users.Update(user);

                var ticket = new Ticket()
                {
                    AuthorId = userId,
                    CategoryId = ticketModel.CategoryId,
                    Description = ticketModel.Description,
                    Priority = ticketModel.Priority,
                    ScreenshotUrl = ticketModel.ScreenshotUrl,
                    Title = ticketModel.Title
                };

                this.data.Tickets.Add(ticket);
                this.data.SaveChanges();

                return RedirectToAction("Details", "Tickets", new { id = ticket.Id });
            }

            ViewBag.Categories = new SelectList(this.data.Categories.All(), "Id", "Name", ticketModel.CategoryId);

            return View(ticketModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CommentOnTicket(PostCommentModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                var username = this.User.Identity.GetUserName();

                var newComment = new Comment()
                {
                    Content = commentModel.Content,
                    TicketId = commentModel.TicketId,
                    UserId = userId
                };

                this.data.Comments.Add(newComment);
                this.data.SaveChanges();

                var viewModel = new CommentViewModel()
                {
                    UserName = username,
                    Content = commentModel.Content
                };

                return PartialView("_CommentPartial", viewModel);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Search(int? categoryId)
        {
            IEnumerable<TicketViewModel> tickets = new List<TicketViewModel>();

            if (categoryId == null)
            {
                tickets = this.data.Tickets.All()
                    .Select(TicketViewModel.FromTicket)
                    .ToList();
            }
            else
            {
                var category = this.data.Categories.GetById(categoryId);
                if (category != null)
                {
                    tickets = category.Tickets
                        .Select(TicketViewModel.FromTicket.Compile())
                        .ToList();
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "This category does not exist anymore");
                }
            }

            return View(tickets);
        }

        [Authorize]
        public ActionResult List()
        {
            return View();
        }

        public JsonResult ReadTickets([DataSourceRequest] DataSourceRequest request)
        {
            var laptops = this.data.Tickets.All()
                .Select(TicketViewModel.FromTicket);

            return Json(laptops.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategories()
        {
            var categories = this.data.Categories.All()
                .Select(CategoryViewModel.FromCategory);

            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }
}