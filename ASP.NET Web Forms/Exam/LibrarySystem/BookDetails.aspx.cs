using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int bookId = Convert.ToInt32(this.Request.Params["id"]);
                var book = context.Books.Find(bookId);

                if (book != null)
                {
                    this.LabelBookTitle.Text = Server.HtmlEncode(book.Title);
                    this.LabelAuthor.Text = "by " + Server.HtmlEncode(book.Author);

                    if (book.ISBN != null)
                    {
                        this.LabelIsbn.Text = "ISBN " + Server.HtmlEncode(book.ISBN);
                    }

                    if (book.WebSite != null)
                    {
                        this.LabelWebSite.Text = Server.HtmlEncode(book.WebSite);
                        this.LabelWebSite.NavigateUrl = Server.HtmlEncode(book.WebSite);
                    }

                    this.LabelDescription.Text = Server.HtmlEncode(book.Description);
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This book doest not exist anymore");
                    this.Response.Redirect("~/Default.aspx");
                }
            }
        }
    }
}