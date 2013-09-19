using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PollSystem.Controls.ErrorSuccessNotifier;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LibrarySystem.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            bool error = false;

            string userName = UserName.Text;
            if (userName == "" || userName.Length < 3)
            {
                ErrorSuccessNotifier.AddErrorMessage("The username must be at least 3 characters");
                error = true;
            }

            string password = Password.Text;
            if (password == "" || password.Length < 6)
            {
                ErrorSuccessNotifier.AddErrorMessage("The password must be at least 6 characters");
                error = true;
            }

            string confirmPassword = ConfirmPassword.Text;
            if (confirmPassword != password)
            {
                ErrorSuccessNotifier.AddErrorMessage("The passwords does not match");
                error = true;
            }

            if (error)
            {
                return;
            }

            var manager = new AuthenticationIdentityManager(new IdentityStore());
            User u = new User(userName) { UserName = userName };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                ErrorSuccessNotifier.AddSuccessMessage("Successfully registered");
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}