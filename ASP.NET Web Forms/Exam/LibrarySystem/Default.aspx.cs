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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                var categories = context.Categories.ToList();
                this.ListViewCategories.DataSource = categories;
                this.ListViewCategories.DataBind();
            }
        }

        protected List<Book> CategoryBooks(int categoryId)
        {
            using (var context = new LibrarySystemEntities())
            {
                var books = context.Books.Where(b => b.CategoryId == categoryId);
                return books.ToList();
            }
        }

        protected void OnButtonSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = this.TextBoxSearch.Text;
            if (searchQuery.Length > 200)
            {
                ErrorSuccessNotifier.AddErrorMessage("Too long search query");
                return;
            }

            this.Response.Redirect(string.Format("~/Search?q={0}", searchQuery));
        }
    }
}