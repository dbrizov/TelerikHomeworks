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
    public partial class EditDeleteQuestions : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        public IQueryable<PollSystem.Models.Question> GridViewQuestions_GetData()
        {
            var dbContext = new PollSystemEntities();
            var questions = dbContext.Questions
                .Include("Answers").OrderBy(q => q.Text);

            return questions;
        }

        protected void OnLinkButtonDeleteQuestion_Command(object sender, CommandEventArgs e)
        {
            var dbContext = new PollSystemEntities();
            int questionId = Convert.ToInt32(e.CommandArgument);
            var question = dbContext.Questions.Find(questionId);

            if (question != null)
            {
                try
                {
                    var answers = question.Answers.ToList();
                    foreach (var answer in answers)
                    {
                        dbContext.Answers.Remove(answer);
                    }

                    dbContext.Questions.Remove(question);
                    dbContext.SaveChanges();

                    this.GridViewQuestions.PageIndex = 0;
                    ErrorSuccessNotifier.AddSuccessMessage("Question successfully deleted");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("This question does not exist anymore");
            }
        }
    }
}