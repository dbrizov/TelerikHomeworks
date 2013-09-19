using Northwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace NorthwindEmployees.FormView
{
    public partial class Employees : System.Web.UI.Page
    {
        List<EmployeeModel> employees = 
            new NorthwindEntities().Employees.Select(EmployeeModel.FromEmployeeEntity()).ToList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                this.employees = (List<EmployeeModel>)ViewState["employees"];
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.EmployeesFormView.DataSource = this.employees;
            this.EmployeesFormView.DataBind();
            ViewState["employees"] = this.employees;
        }

        protected void EmployeesFormView_PageIndexChanging(
            object sender, FormViewPageEventArgs e)
        {
            this.EmployeesFormView.PageIndex = e.NewPageIndex;
            this.EmployeesFormView.DataSource = this.employees;
            this.EmployeesFormView.DataBind();
        }
    }
}