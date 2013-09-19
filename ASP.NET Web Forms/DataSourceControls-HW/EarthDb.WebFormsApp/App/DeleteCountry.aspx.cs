using EarthDb.WebFormsApp.Database;
using System;
using System.Linq;

namespace EarthDb.WebFormsApp.App
{
    public partial class DeleteCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBtnYes_Click(object sender, EventArgs e)
        {
            var dbContext = new EarthDbEntities();
            using (dbContext)
            {
                int countryId = int.Parse(this.Request.Params["countryId"]);
                var country = dbContext.Countries.Find(countryId);

                if (country != null)
                {
                    dbContext.Countries.Remove(country);
                    dbContext.SaveChanges();
                }

                this.Response.Redirect("AppMain.aspx");
            }
        }

        protected void OnBtnNo_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AppMain.aspx");
        }
    }
}