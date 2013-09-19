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
    public partial class EditCategories : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<LibrarySystem.Models.Category> GridViewCategories_GetData()
        {
            var context = new LibrarySystemEntities();
            return context.Categories.OrderBy(cat => cat.Name);
        }

        protected void OnButtonSaveCategory_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    try
                    {
                        string categoryName = this.TextBoxEditCategoryName.Text;
                        if (categoryName == "")
                        {
                            ErrorSuccessNotifier.AddErrorMessage("The category cannot be empty");
                            return;
                        }

                        category.Name = categoryName;
                        context.SaveChanges();

                        ErrorSuccessNotifier.AddSuccessMessage("Category modified");
                        this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
                        this.PanelEditCategory.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This category does not exist anymore");
                }
            }
        }

        protected void OnButtonShowEditCategory_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    this.PanelCreateCategory.Visible = false;
                    this.PanelDeleteCategory.Visible = false;
                    this.PanelEditCategory.Visible = true;
                    this.TextBoxEditCategoryName.Text = category.Name;
                    this.ButtonSaveCategory.CommandArgument = categoryId.ToString();
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This category does not exist anymore");
                }
            }
        }

        protected void OnButtonCreateCategory_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                try
                {
                    string categoryName = this.TextBoxCreateCategoryName.Text.Trim();
                    if (categoryName == "")
                    {
                        ErrorSuccessNotifier.AddErrorMessage("The category cannot be empty");
                        return;
                    }

                    var existingCategory = context.Categories.FirstOrDefault(
                        cat => cat.Name.ToLower() == categoryName.ToLower());

                    if (existingCategory != null)
                    {
                        this.PanelCreateCategory.Visible = false;
                        ErrorSuccessNotifier.AddErrorMessage("This category already exists");
                        return;
                    }

                    var newCategory = new Category()
                    {
                        Name = categoryName
                    };

                    context.Categories.Add(newCategory);
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Category created");
                    this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
                    this.PanelCreateCategory.Visible = false;
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void OnButtonShowCreateCategory_Command(object sender, CommandEventArgs e)
        {
            this.PanelEditCategory.Visible = false;
            this.PanelDeleteCategory.Visible = false;
            this.PanelCreateCategory.Visible = true;
        }

        protected void OnButtonDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    try
                    {
                        var books = category.Books.ToList();
                        foreach (var book in books)
                        {
                            context.Books.Remove(book);
                        }

                        context.Categories.Remove(category);
                        context.SaveChanges();

                        ErrorSuccessNotifier.AddSuccessMessage("Category deleted");
                        this.GridViewCategories.SetPageIndex(this.GridViewCategories.PageIndex);
                        this.PanelDeleteCategory.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(ex);
                    }
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This category does not exist anymore");
                }
            }
        }

        protected void OnButtonShowDeleteCategory_Command(object sender, CommandEventArgs e)
        {
            using (var context = new LibrarySystemEntities())
            {
                int categoryId = Convert.ToInt32(e.CommandArgument);
                var category = context.Categories.Find(categoryId);

                if (category != null)
                {
                    this.PanelEditCategory.Visible = false;
                    this.PanelCreateCategory.Visible = false;
                    this.PanelDeleteCategory.Visible = true;
                    this.TextBoxDeleteCategoryName.Text = category.Name;
                    this.ButtonDeleteCategory.CommandArgument = categoryId.ToString();
                }
                else
                {
                    ErrorSuccessNotifier.AddErrorMessage("This category does not exist anymore");
                }
            }
        }

        protected void OnButtonCancelCreate_Click(object sender, EventArgs e)
        {
            this.PanelCreateCategory.Visible = false;
        }

        protected void OnButtonCancelEdit_Click(object sender, EventArgs e)
        {
            this.PanelEditCategory.Visible = false;
        }

        protected void OnButtonDontDelete_Click(object sender, EventArgs e)
        {
            this.PanelDeleteCategory.Visible = false;
        }
    }
}