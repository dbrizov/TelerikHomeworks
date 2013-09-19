using System;
using System.Linq;

namespace AspNetWebAndHtmlControls
{
    public partial class _02_RandomNumberServerControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerateRandomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.FromRange.Text);
                int to = int.Parse(this.ToRange.Text);

                Random rand = new Random();
                int randomNumber = rand.Next(from, to + 1);

                this.RandomNumberContainer.Text = randomNumber.ToString();
            }
            catch (Exception)
            {
                this.RandomNumberContainer.Text = "Error!";
            }
        }
    }
}