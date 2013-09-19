using PollSystem.Controls.ErrorSuccessNotifier;
using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class VotingResults : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            var question = dbContext.Questions.Find(questionId);

            if (question != null)
            {
                this.LabelQuestionText.Text = Server.HtmlEncode(question.Text);

                this.RepeaterAnswers.DataSource = question.Answers.ToList();
                this.DataBind();
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This question does not exist anymore");
            }
        }
    }
}