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
    public partial class Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var dbContext = new PollSystemEntities();
            var questions = dbContext.Questions
                .Include("Answers").OrderBy(q => Guid.NewGuid()).Take(3);

            this.ListViewPollQuestions.DataSource = questions.ToList();
            this.DataBind();
        }

        protected void OnBtnVote_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int answerId = Convert.ToInt32(e.CommandArgument);

            var answer = dbContext.Answers.Find(answerId);
            if (answer != null)
            {
                answer.Votes++;
                dbContext.SaveChanges();

                ErrorSuccessNotifier.AddInfoMessage("You voted for " + answer.Text);
                Response.Redirect("~/VotingResults.aspx?questionId=" + answer.QuestionId);
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This answer does not exist anymore");
            }
        }
    }
}