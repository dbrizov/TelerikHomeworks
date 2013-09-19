using System;
using System.Linq;

namespace Validation
{
    public partial class FormRegister : System.Web.UI.Page
    {
        public void PersonInfoBtn_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("personalInfo");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            if (!this.accept.Checked)
            {
                this.acceptValidator.IsValid = false;
            }

            if (this.CheckIsValid("loginInfo"))
            {
               
            }

            if (this.CheckIsValid("additinalInfo"))
            {
                
            }

            if (this.CheckIsValid("personalInfo"))
            {
                //do something
            }
        }

        protected void LoginValidate_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("loginInfo");
        }

        protected void AdditinalInfoBtn_Click(object sender, EventArgs e)
        {
            this.CheckIsValid("additinalInfo");
        }

        private bool CheckIsValid(string validationGroup)
        {
            this.Page.Validate(validationGroup);
            if (this.Page.IsValid)
            {
                return true;
            }
            return false;
        }
    }
}