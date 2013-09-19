using PollSystem.Controls.ErrorSuccessNotifier;
using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem.LoggedUsers
{
    public partial class AllQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterAnswers.DataSource = null;
            this.RepeaterAnswers.DataBind();
        }

        public IQueryable<Question> GridViewQuestions_GetData()
        {
            var dbContext = new PollSystemEntities();
            return dbContext.Questions.OrderBy(q => q.Text);
        }

        protected void GridViewQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int questionId = 
                Convert.ToInt32(this.GridViewQuestions.SelectedDataKey.Value);

            var question = dbContext.Questions.Find(questionId);
            if (question != null)
            {
                this.RepeaterAnswers.DataSource = question.Answers.ToList();
                this.RepeaterAnswers.DataBind();
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This question doesn't exist anymore");
            }
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