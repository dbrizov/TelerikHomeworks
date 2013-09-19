using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                string queryString = this.Request.Params["q"];
                string queryStringToLower = queryString.ToLower();

                if (queryStringToLower == "")
                {
                    this.ListViewBooks.DataSource = context.Books.Include("Category").ToList();
                }
                else
                {
                    var books = context.Books.Include("Category").Where(
                        b => b.Title.ToLower().Contains(queryStringToLower) || b.Author.Contains(queryStringToLower))
                        .OrderBy(b => b.Title).ThenBy(b => b.Author);

                    this.ListViewBooks.DataSource = books.ToList();
                }

                this.LabelSearchQueryHeader.Text = string.Format("Search Results for Query \"{0}\"", Server.HtmlEncode(queryString));
                this.ListViewBooks.DataBind();
            }
        }
    }
}