using Northwind.Data;
using System;
using System.Linq;

namespace NorthwindEmployees.GridView
{
    public partial class EmployeeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new NorthwindEntities();
            using (dbContext)
            {
                var id = int.Parse(Request.QueryString["id"]);
                var employee = dbContext.Employees.Where(emp => emp.EmployeeID == id).ToList();

                this.EmployeeDetailsView.DataSource = employee;
                this.DataBind();
            }
        }
    }
}