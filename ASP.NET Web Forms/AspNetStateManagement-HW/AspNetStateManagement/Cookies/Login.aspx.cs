using System;
using System.Linq;
using System.Web;

namespace AspNetStateManagement.Cookies
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["username"];
            if (cookie != null)
            {
                Response.Redirect("Logged.aspx?user=" + Request.Cookies["username"].Value);
            }
        }

        protected void OnBtnLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("username", "Pesho");
            cookie.Expires = DateTime.Now.AddMinutes(1);

            Response.Cookies.Add(cookie);
        }
    }
}