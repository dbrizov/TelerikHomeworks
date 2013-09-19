using Northwind.Data;
using System;
using System.Linq;

namespace NorthwindEmployees.GridView
{
    public partial class GridView : System.Web.UI.Page
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
                    from employee in dbContext.Employees.ToList()
                    select new
                    {
                        Id = employee.EmployeeID,
                        FullName = employee.FirstName + " " + employee.LastName
                    };

                this.EmployeesGrid.DataSource = employees;
                this.DataBind();
            }
        }
    }
}