using System;
using System.Linq;

namespace AspNetStateManagement.Session
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.Session["text"] == null)
            {
                this.Session["text"] = "";
            }

            this.LabelContainer.Text = this.Server.HtmlEncode(this.Session["text"].ToString());
        }

        protected void OnBtnAddText_Click(object sender, EventArgs e)
        {
            string text = this.TextBoxInput.Text;
            this.Session["text"] += text;
        }
    }
}