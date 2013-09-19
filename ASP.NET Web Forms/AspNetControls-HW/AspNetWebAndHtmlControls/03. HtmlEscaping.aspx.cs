using System;
using System.Linq;

namespace AspNetWebAndHtmlControls
{
    public partial class _03_HtmlEscaping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnOutput_Click(object sender, EventArgs e)
        {
            var input = Server.HtmlEncode(this.TextBoxInput.Text);

            this.TextBoxOutput.Text = input;
            this.LabelOutput.Text = input;
        }
    }
}