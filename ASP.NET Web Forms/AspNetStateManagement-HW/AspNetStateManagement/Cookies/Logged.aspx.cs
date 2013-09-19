using System;
using System.Linq;

namespace AspNetStateManagement.Cookies
{
    public partial class Logged : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            string username = this.Request.Params["user"];

            this.LabelUsername.Text = this.Server.HtmlEncode(username);
        }
    }
}