using Northwind.Data;
using System;
using System.Linq;

namespace NorthwindEmployees.Repeater
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            var dbContext = new NorthwindEntities();
            using (dbContext)
            {
                var employees =
                    dbContext.Employees.Select(EmployeeModel.FromEmployeeEntity()).ToList();

                this.RepeaterEmployees.DataSource = employees;
                this.DataBind();
            }
        }
    }
}