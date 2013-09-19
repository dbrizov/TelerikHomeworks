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
    public partial class AddQuestion : System.Web.UI.Page
    {
        private static List<string> answers = new List<string>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            foreach (var answer in answers)
            {
                var label = new Label()
                {
                    Text = Server.HtmlEncode(answer) + "<br/>"
                };

                this.PanelAnswers.Controls.Add(label);
            }
        }

        protected void OnBtnAddAnswer_Click(object sender, EventArgs e)
        {
            string answerText = this.TextBoxAnswerText.Text;
            if (answerText.Length < 2 || answerText.Length >= 100)
            {
                ErrorSuccessNotifier.AddErrorMessage("The answer's length must be in range [2, 100] inclusive");
            }
            else
            {
                answers.Add(answerText);
                this.TextBoxAnswerText.Text = "";
            }
        }

        protected void OnBtnCreateQuestion_Click(object sender, EventArgs e)
        {
            string questionText = this.TextBoxQuestionText.Text;
            if (questionText.Length < 4)
            {
                ErrorSuccessNotifier.AddErrorMessage("The question's length must be in range [4, 200] inclusive");

                if (answers.Count < 2)
                {
                    ErrorSuccessNotifier.AddErrorMessage("The question must have at least 2 answers");
                }
            }
            else if (answers.Count < 2)
            {
                ErrorSuccessNotifier.AddErrorMessage("The question must have at least 2 answers");
            }
            else
            {
                var question = new Question()
                {
                    Answers = answers.Select(answer => new Answer() { Text = answer }).ToList(),
                    Text = questionText
                };

                try
                {
                    var dbContext = new PollSystemEntities();
                    dbContext.Questions.Add(question);
                    dbContext.SaveChanges();

                    this.TextBoxQuestionText.Text = "";
                    answers = new List<string>();
                    ErrorSuccessNotifier.AddSuccessMessage("Question created");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void OnBtnClearAnswers_Click(object sender, EventArgs e)
        {
            answers = new List<string>();
        }
    }
}