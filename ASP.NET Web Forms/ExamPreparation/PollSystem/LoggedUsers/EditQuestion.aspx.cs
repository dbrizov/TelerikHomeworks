using PollSystem.Controls.ErrorSuccessNotifier;
using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem.LoggedUsers
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            var question = dbContext.Questions.Find(questionId);

            if (question != null)
            {
                this.TextBoxQuestionText.Text = question.Text;

                var answers = question.Answers.ToList();
                this.RepeaterAnswers.DataSource = answers;
                this.RepeaterAnswers.DataBind();
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This question does not exist anymore");
            }
        }

        protected void OnLinkButtonDeleteAnswer_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int answerId = Convert.ToInt32(e.CommandArgument);
            var answer = dbContext.Answers.Find(answerId);

            if (answer != null)
            {
                try
                {
                    dbContext.Answers.Remove(answer);
                    dbContext.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Answer successfully deleted");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This answer does not exist anymore");
            }
        }

        protected void OnBtnSaveChanges_Click(object sender, EventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            var question = dbContext.Questions.Find(questionId);

            if (question != null)
            {
                try
                {
                    string questionText = this.TextBoxQuestionText.Text;
                    question.Text = questionText;
                    dbContext.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Question successfully edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This question does not exist anymore");
            }
        }
    }
}