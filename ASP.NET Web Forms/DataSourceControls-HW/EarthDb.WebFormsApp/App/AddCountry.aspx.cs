using EarthDb.WebFormsApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EarthDb.WebFormsApp.App
{
    public partial class AddCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnBtnAddCountry_Click(object sender, EventArgs e)
        {
            var dbContext = new EarthDbEntities();
            using (dbContext)
            {
                int continentId = int.Parse(this.Request.Params["continentId"]);
                var continent = dbContext.Continents.Find(continentId);

                if (continent != null)
                {
                    string countryName = this.TextBoxCountryName.Text;
                    int countryPopulation = int.Parse(this.TextBoxCountryPopulation.Text);
                    string countryLanguage = this.TextBoxCountryLanguage.Text;

                    var newCountry = new Country()
                    {
                        Continent = continent,
                        Language = countryLanguage,
                        Name = countryName,
                        Population = countryPopulation
                    };

                    dbContext.Countries.Add(newCountry);
                    dbContext.SaveChanges();

                    Response.Redirect("AppMain.aspx");
                }
            }
        }
    }
}