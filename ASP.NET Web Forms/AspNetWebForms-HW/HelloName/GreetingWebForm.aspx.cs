using System;
using System.Linq;

namespace HelloName
{
    public partial class GreetBot : System.Web.UI.Page
    {
        protected void ButtonHelloName_Click(object sender, EventArgs e)
        {
            string name = this.TextBoxName.Text;
            Response.Write("Hello " + name);
        }
    }
}