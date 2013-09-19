using EarthDb.WebFormsApp.Database;
using System;
using System.Linq;

namespace EarthDb.WebFormsApp.App
{
    public partial class AddTown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var dbContext = new EarthDbEntities();
            using (dbContext)
            {
                var countries = dbContext.Countries.OrderBy(town => town.Name).ToList();
                this.DropDownListCountries.DataSource = countries;
                this.DataBind();
            }
        }

        protected void OnBtnAddTown_Click(object sender, EventArgs e)
        {
            var dbContext = new EarthDbEntities();
            using (dbContext)
            {
                int countryId = int.Parse(this.DropDownListCountries.SelectedValue);
                var country = dbContext.Countries.Find(countryId);

                if (country != null)
                {
                    var newTown = new Town()
                    {
                        Country = country,
                        Name = this.TextBoxTownName.Text,
                        Population = this.TextBoxTownPopulation.Text
                    };

                    dbContext.Towns.Add(newTown);
                    dbContext.SaveChanges();

                    this.Response.Redirect("AppMain.aspx");
                }
            }
        }
    }
}