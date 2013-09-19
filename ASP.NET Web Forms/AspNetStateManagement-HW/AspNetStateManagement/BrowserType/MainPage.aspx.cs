using System;
using System.Linq;

namespace AspNetStateManagement.BrowserType
{
    public partial class BrowserType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LabelInfo.Text += "Browser: " + this.Request.Browser.Type + "<br />";
            this.LabelInfo.Text += "Client IP: " + this.Request.ServerVariables["REMOTE_ADDR"] + "<br />";
        }
    }
}