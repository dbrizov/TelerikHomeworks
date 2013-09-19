using System;
using System.Linq;

namespace AspNetWebAndHtmlControls
{
    public partial class RandomNumberHtmlControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGenerateRandomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int from = int.Parse(this.FromRange.Value);
                int to = int.Parse(this.ToRange.Value);

                Random rand = new Random();
                int randomNumber = rand.Next(from, to + 1);

                this.RandomNumberContainer.Value = randomNumber.ToString();
            }
            catch (Exception)
            {
                this.RandomNumberContainer.Value = "Error!";
            }
        }
    }
}