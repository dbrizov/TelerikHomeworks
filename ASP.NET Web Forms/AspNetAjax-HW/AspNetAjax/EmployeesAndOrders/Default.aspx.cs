using System;
using System.Linq;
using System.Threading;
using System.Web.UI.WebControls;

namespace AspNetAjax.EmployeesAndOrders
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        public IQueryable<Employee> GridViewEmployees_GetData()
        {
            var dbContext = new NorthwindEntities();
            return dbContext.Employees.OrderBy(emp => emp.EmployeeID);
        }

        protected void GridViewEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(3000);

            this.GridViewOrders.PageIndex = 0;
            this.DataBindGridViewOrders();
        }

        protected void GridViewOrders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewOrders.PageIndex = e.NewPageIndex;
            this.DataBindGridViewOrders();
        }

        private void DataBindGridViewOrders()
        {
            var dbContext = new NorthwindEntities();
            int employeeId = Convert.ToInt32(this.GridViewEmployees.SelectedDataKey.Value);

            var orders = dbContext.Orders
                .Where(ord => ord.EmployeeID == employeeId).ToList();

            this.GridViewOrders.DataSource = orders;
            this.GridViewOrders.DataBind();
        }
    }
}