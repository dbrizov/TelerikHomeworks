using AspNetMvcExam.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetMvcExam.Web.Models
{
    public class TicketViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public int CommentsCount { get; set; }

        public TicketPriority Priority { get; set; }

        public static Expression<Func<Ticket, TicketViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketViewModel()
                {
                    AuthorName = ticket.Author.UserName,
                    CategoryName = ticket.Category.Name,
                    CommentsCount = ticket.Comments.Count(),
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Priority = ticket.Priority
                };
            }
        }
    }
}