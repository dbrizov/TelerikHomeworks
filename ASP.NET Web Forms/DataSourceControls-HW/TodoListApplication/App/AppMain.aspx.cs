using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TodoListApplication.Database;

namespace TodoListApplication.App
{
    public partial class AppMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            this.BindCategories();
        }

        protected void IsDoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                var checkBox = (CheckBox)sender;
                var todoListItem = checkBox.Parent;
                var childControls = todoListItem.Controls;

                for (int i = 0; i < childControls.Count; i++)
                {
                    if (childControls[i] is Label && childControls[i].Visible == false)
                    {
                        int todoId = int.Parse((childControls[i] as Label).Text);
                        var todo = dbContext.Todos.Find(todoId);

                        if (todo != null)
                        {
                            todo.IsDone = !todo.IsDone;
                            todo.DateOfLastChange = DateTime.Now;
                            dbContext.SaveChanges();

                            this.BindTodosForCurrentCategory();
                        }

                        break;
                    }
                }
            }
        }

        protected void OnBtnAddCategory_Click(object sender, EventArgs e)
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                string categoryName = this.TextBoxCategoryName.Text.ToLower();
                var existingCategory = dbContext.Categories
                    .FirstOrDefault(cat => cat.Name.ToLower() == categoryName);

                if (existingCategory != null)
                {
                    this.TextBoxCategoryName.Text = "This category already exists";
                }
                else
                {
                    var newCategory = new Category()
                    {
                        Name = categoryName
                    };

                    dbContext.Categories.Add(newCategory);
                    dbContext.SaveChanges();

                    this.TextBoxCategoryName.Text = "";
                    this.BindCategories();
                }
            }
        }

        protected void OnBtnDeleteCategory_Click(object sender, EventArgs e)
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                int categoryId = int.Parse(this.DropDownListCategories.SelectedValue);
                var category = dbContext.Categories.Find(categoryId);

                if (category != null)
                {
                    dbContext.Categories.Remove(category);
                    dbContext.SaveChanges();

                    this.BindCategories();
                }
            }
        }

        protected void OnBtnAddTodo_Click(object sender, EventArgs e)
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                int selectedCategoryId = int.Parse(this.ListBoxCategories.SelectedValue);
                var selectedCategory = dbContext.Categories.Find(selectedCategoryId);

                if (selectedCategory != null)
                {
                    string todoBody = this.TextBoxTodoBody.Text;
                    var existingTodo = selectedCategory.Todos.FirstOrDefault(todo => todo.Body.ToLower() == todoBody.ToLower());
                    if (existingTodo != null)
                    {
                        this.TextBoxTodoBody.Text = "This todo already exisits";
                    }
                    else
                    {
                        var newTodo = new Todo()
                        {
                            Body = todoBody,
                            Category = selectedCategory,
                            DateOfLastChange = DateTime.Now,
                            IsDone = false
                        };

                        dbContext.Todos.Add(newTodo);
                        dbContext.SaveChanges();

                        this.TextBoxTodoBody.Text = "";
                        this.BindTodosForCurrentCategory();
                    }
                }
            }
        }

        protected void OnListBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindTodosForCurrentCategory();
        }

        protected void OnBtnDeleteTodo_Click(object sender, EventArgs e)
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                var button = (Button)sender;
                var todoListItem = button.Parent;
                var childControls = todoListItem.Controls;

                for (int i = 0; i < childControls.Count; i++)
                {
                    if (childControls[i] is Label && childControls[i].Visible == false)
                    {
                        int todoId = int.Parse((childControls[i] as Label).Text);
                        var todo = dbContext.Todos.Find(todoId);

                        if (todo != null)
                        {
                            dbContext.Todos.Remove(todo);
                            dbContext.SaveChanges();

                            this.BindTodosForCurrentCategory();
                        }

                        break;
                    }
                }
            }
        }

        private void BindTodosForCurrentCategory()
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                int selectedCategoryId = int.Parse(this.ListBoxCategories.SelectedValue);
                var selectedCategory = dbContext.Categories.Find(selectedCategoryId);

                if (selectedCategory != null)
                {
                    var todosForCurrentCategory = dbContext.Todos.Where(todo => todo.CategoryId == selectedCategoryId).ToList();
                    this.ListViewTodos.DataSource = todosForCurrentCategory;
                    this.DataBind();
                }
            }
        }

        private void BindCategories()
        {
            var dbContext = new TodoListDbEntities();
            using (dbContext)
            {
                var categories = dbContext.Categories.ToList();
                if (categories.Count > 0)
                {
                    this.DropDownListCategories.DataSource = categories;
                    this.ListBoxCategories.DataSource = categories;
                }

                this.DataBind();
            }
        }
    }
}