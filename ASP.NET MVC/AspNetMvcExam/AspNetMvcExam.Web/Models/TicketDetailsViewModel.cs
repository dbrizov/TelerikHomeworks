using AspNetMvcExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetMvcExam.Web.Models
{
    public class TicketDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public TicketPriority Priority { get; set; }

        public string AuthorName { get; set; }

        public string ScreenshotUrl { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public static Expression<Func<Ticket, TicketDetailsViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketDetailsViewModel()
                {
                    Id = ticket.Id,
                    AuthorName = ticket.Author.UserName,
                    CategoryName = ticket.Category.Name,
                    Comments = ticket.Comments.Select(CommentViewModel.FromComment.Compile()),
                    Description = ticket.Description,
                    Priority = ticket.Priority,
                    ScreenshotUrl = ticket.ScreenshotUrl,
                    Title = ticket.Title
                };
            }
        }
    }
}