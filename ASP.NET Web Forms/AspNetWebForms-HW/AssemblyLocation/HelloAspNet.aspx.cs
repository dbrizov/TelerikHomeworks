using System;
using System.Linq;
using System.Reflection;

namespace AssemblyLocation
{
    public partial class CodeBehind : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Assembly location: " + Assembly.GetExecutingAssembly().Location);
            Response.Write("<br />");
            Response.Write("Hello ASP.NET - from code behind\r\n");
        }
    }
}