using System;
using System.Linq;

namespace NumberSumator
{
    public partial class Sumator : System.Web.UI.Page
    {
        protected void ButtonCalculateSum_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNumber = double.Parse(this.TextBoxFirstNum.Text);
                double secondNumer = double.Parse(this.TextBoxSecondNum.Text);
                double sum = firstNumber + secondNumer;

                this.TextBoxtResult.Text = sum.ToString();
            }
            catch (FormatException)
            {
                this.TextBoxtResult.Text = "Error!";
            }
        }
    }
}