using Chat.Models;
using System;
using System.Linq;

namespace Chat
{
    public partial class Messages : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var dbContext = new ChatEntities();
            int messagesCount = dbContext.Messages.Count();

            IQueryable<Message> messages = null;
            if (messagesCount > 15)
            {
                messages = dbContext.Messages.Include("User")
                    .OrderBy(msg => msg.PostDate).Skip(messagesCount - 15).Take(15);
            }
            else
            {
                messages = dbContext.Messages.Include("User");
            }

            this.ListViewMessages.DataSource = messages.ToList();
            this.ListViewMessages.DataBind();
        }

        protected void OnBtnSendMessage_Click(object sender, EventArgs e)
        {
            var dbContext = new ChatEntities();
            var currentUser = dbContext.Users.FirstOrDefault(
                u => u.UserName == User.Identity.Name);

            if (currentUser != null)
            {
                Message newMessage = new Message()
                {
                    Text = this.TextBoxNewMessageText.Text,
                    User = currentUser,
                    PostDate = DateTime.Now
                };

                dbContext.Messages.Add(newMessage);
                dbContext.SaveChanges();

                this.TextBoxNewMessageText.Text = "";
            }
        }
    }
}