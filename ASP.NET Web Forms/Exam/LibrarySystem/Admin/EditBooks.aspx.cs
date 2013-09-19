using LibrarySystem.Models;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibrarySystem.Admin
{
    public partial class EditBooks : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                var categories = context.Categories.ToList();
                this.DropDownCreateCategories.DataSource = categories;
                this.DropDownEditCategories.DataSource = categories;

                this.DataBind();
            }
        }

        public IQueryable<LibrarySystem.Models.Book> GridViewBooks_GetData()
        {
            var context = new LibrarySystemEntities();
            return context.Books.Include("Category").OrderBy(b => b.Title);
        }

        protected void OnButtonShowCreateBookPanel_Command(object sender, CommandEventArgs e)
        {
            this.ShowCreateBookPanel();
        }

        protected void OnButtonCreateBook_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                try
                {
                    bool error = false;

                    int categoryId = Convert.ToInt32(this.DropDownCreateCategories.SelectedValue);
                    var category = context.Categories.Find(categoryId);

                    string title = this.TextBoxCreateBookTitle.Text.Trim();
                    if (title == null || title == "")
                    {
                        ErrorSuccessNotifier.AddErrorMessage("The title field is required");
                        error = true;
                    }
                    else
                    {
                        var existingBook = context.Books.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
                        if (existingBook != null)
                        {
                            ErrorSuccessNotifier.AddErrorMessage("A book with the same title already exist");
                            return;
                        }
                    }

                    string authors = this.TextBoxCreateBookAuthors.Text;
                    if (authors == null || authors == "")
                    {
                        ErrorSuccessNotifier.AddErrorMessage("The author(s) field is required");
                        error = true;
                    }

                    if (error)
                    {
                        return;
                    }

                    string isbn = this.TextBoxCreateBookISBN.Text;
                    if (isbn != "")
                    {
                        var existingBook = context.Books.FirstOrDefault(b => b.ISBN.ToLower() == isbn.ToLower());
                        if (existingBook != null)
                        {
                            ErrorSuccessNotifier.AddErrorMessage("A book with the same ISBN already exist");
                            return;
                        }
                    }

                    string webSite = this.TextBoxCreateBookWebSite.Text;
                    string description = this.TextBoxCreateBookDescription.Text;

                    var newBook = new Book();
                    newBook.Title = title;
                    newBook.Author = authors;
                    newBook.Category = category;

                    if (isbn != "")
                    {
                        newBook.ISBN = isbn;
                    }

                    if (webSite != "")
                    {
                        newBook.WebSite = webSite;
                    }

                    if (description != "")
                    {
                        newBook.Description = description;
                    }

                    context.Books.Add(newBook);
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Book created");
                    this.PanelCreateBook.Visible = false;
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void OnButtonCancelCreate_Click(object sender, EventArgs e)
        {
            this.PanelCreateBook.Visible = false;
        }

        protected void OnButtonShowEditBookPanel_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                if (book != null)
                {
                    this.ShowEditBookPanel();
                    this.ButtonEditBook.CommandArgument = bookId.ToString();

                    this.DropDownEditCategories.SelectedValue = book.CategoryId.ToString();
                    this.TextBoxEditBookAuthors.Text = book.Author;
                    this.TextBoxEditBookDescription.Text = book.Description;
                    this.TextBoxEditBookISBN.Text = book.ISBN;
                    this.TextBoxEditBookTitle.Text = book.Title;
                    this.TextBoxEditBookWebSite.Text = book.WebSite;
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This book does not exist anymore");
                }
            }
        }

        protected void OnButtonEditBook_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                if (book != null)
                {
                    try
                    {
                        bool error = false;

                        int categoryId = Convert.ToInt32(this.DropDownEditCategories.SelectedValue);
                        var category = context.Categories.Find(categoryId);

                        string title = this.TextBoxEditBookTitle.Text.Trim();
                        if (title == null || title == "")
                        {
                            ErrorSuccessNotifier.AddErrorMessage("The title field is required");
                            error = true;
                        }

                        string authors = this.TextBoxEditBookAuthors.Text;
                        if (authors == null || authors == "")
                        {
                            ErrorSuccessNotifier.AddErrorMessage("The author(s) field is required");
                            error = true;
                        }

                        if (error)
                        {
                            return;
                        }

                        string isbn = this.TextBoxEditBookISBN.Text;
                        string webSite = this.TextBoxEditBookWebSite.Text;
                        string description = this.TextBoxEditBookDescription.Text;

                        book.Title = title;
                        book.Author = authors;
                        book.Category = category;

                        if (isbn != "")
                        {
                            book.ISBN = isbn;
                        }

                        if (webSite != "")
                        {
                            book.WebSite = webSite;
                        }

                        if (description != "")
                        {
                            book.Description = description;
                        }

                        context.SaveChanges();

                        ErrorSuccessNotifier.AddSuccessMessage("Book modified");
                        this.PanelEditBook.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This book does not exist anymore");
                }
            }
        }

        protected void OnButtonCancelEdit_Click(object sender, EventArgs e)
        {
            this.PanelEditBook.Visible = false;
        }

        protected void OnButtonShowDeleteBookPanel_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                if (book != null)
                {
                    this.ShowDeleteBookPanel();
                    this.ButtonDeleteBook.CommandArgument = bookId.ToString();

                    this.TextBoxDeleteBookTitle.Text = book.Title;
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This book does not exist anymore");
                }
            }
        }

        protected void OnButtonDeleteBook_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                var book = context.Books.Find(bookId);

                if (book != null)
                {
                    try
                    {
                        context.Books.Remove(book);
                        context.SaveChanges();

                        ErrorSuccessNotifier.AddSuccessMessage("Book deleted");
                        this.PanelDeleteBook.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage("This book does not exist anymore");
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This book does not exist anymore");
                }
            }
        }

        protected void OnButtonCancelDelete_Click(object sender, EventArgs e)
        {
            this.PanelDeleteBook.Visible = false;
        }

        protected string CutString(string str)
        {
            if (str != null && str.Length > 20)
            {
                str = str.Substring(0, 20) + "...";
            }

            return str;
        }

        private void ShowCreateBookPanel()
        {
            this.PanelCreateBook.Visible = true;
            this.PanelDeleteBook.Visible = false;
            this.PanelEditBook.Visible = false;

            this.TextBoxCreateBookAuthors.Text = "";
            this.TextBoxCreateBookDescription.Text = "";
            this.TextBoxCreateBookISBN.Text = "";
            this.TextBoxCreateBookTitle.Text = "";
            this.TextBoxCreateBookWebSite.Text = "";
        }

        private void ShowEditBookPanel()
        {
            this.PanelEditBook.Visible = true;
            this.PanelCreateBook.Visible = false;
            this.PanelDeleteBook.Visible = false;
        }

        private void ShowDeleteBookPanel()
        {
            this.PanelDeleteBook.Visible = true;
            this.PanelCreateBook.Visible = false;
            this.PanelEditBook.Visible = false;
        }
    }
}