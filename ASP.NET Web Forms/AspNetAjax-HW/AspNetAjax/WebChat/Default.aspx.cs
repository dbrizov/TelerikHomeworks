using System;
using System.Linq;

namespace AspNetAjax.WebChat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void TimerRefresh_Tick(object sender, EventArgs e)
        {
            var dbContext = new SimpleWebChatEntities();

            var messages = dbContext.Messages.ToList();
            if (messages.Count() > 15)
            {
                messages = messages.Skip(messages.Count() - 15).Take(15).ToList();
            }

            this.ListViewMessages.DataSource = messages;
            this.ListViewMessages.DataBind();
        }

        protected void OnBtnSendMessage_Click(object sender, EventArgs e)
        {
            var dbContext = new SimpleWebChatEntities();

            var newMessage = new Message()
            {
                Text = this.TextBoxNewMessageText.Text
            };

            dbContext.Messages.Add(newMessage);
            dbContext.SaveChanges();

            this.TextBoxNewMessageText.Text = "";
            this.UpdatePanelSendMessage.Update();
        }
    }
}