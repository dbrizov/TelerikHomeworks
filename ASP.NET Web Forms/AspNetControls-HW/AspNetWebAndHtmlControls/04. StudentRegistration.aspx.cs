using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetWebAndHtmlControls
{
    public partial class _04_StudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            string firstName = this.TextBoxFirstName.Text;
            string lastName = this.TextBoxLastName.Text;
            string facultyNumber = this.TextBoxFacultyNumber.Text;
            string university = this.DropDownUniversities.SelectedItem.Text;

            List<string> courses = new List<string>();
            foreach (var index in this.ListBoxCourses.GetSelectedIndices())
            {
                courses.Add(this.ListBoxCourses.Items[index].Text);
            }

            this.SummaryHeader.InnerText = "Registered successfully";
            this.StudentFirstName.InnerHtml = string.Format("First name: <strong>{0}</strong>", firstName);
            this.StudentLastName.InnerHtml = string.Format("Last name: <strong>{0}</strong>", lastName);
            this.StudentFacultyNumber.InnerHtml = string.Format("Faculty number: <strong>{0}</strong>", facultyNumber);
            this.StudentUniversity.InnerHtml = string.Format("University: <strong>{0}</strong>", university);

            StringBuilder coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Courses: ");
            for (int i = 0; i < courses.Count; i++)
            {
                coursesBuilder.AppendFormat("<strong>{0}, </strong>", courses[i]);
            }

            this.StudentCourses.InnerHtml = coursesBuilder.ToString();
        }
    }
}