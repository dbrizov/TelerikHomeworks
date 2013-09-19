using EarthDb.WebFormsApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EarthDb.WebFormsApp.App
{
    public partial class EditCountry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var context = new EarthDbEntities();
            //using (context)
            //{
            //    int countryId = int.Parse(this.Request.Params["countryId"]);
            //    var country = context.Countries.Find(countryId);

            //    if (country != null)
            //    {
            //        this.TextBoxCountryName.Text = country.Name;
            //        this.TextBoxCountryLanguage.Text = country.Language;
            //        this.TextBoxCountryPopulation.Text = country.Population.ToString();
            //    }
            //}
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            var context = new EarthDbEntities();
            using (context)
            {
                int countryId = int.Parse(this.Request.Params["countryId"]);
                var country = context.Countries.Find(countryId);

                if (country != null)
                {
                    this.TextBoxCountryName.Text = country.Name;
                    this.TextBoxCountryLanguage.Text = country.Language;
                    this.TextBoxCountryPopulation.Text = country.Population.ToString();
                }
            }
        }

        protected void OnBtnEditCountry_Click(object sender, EventArgs e)
        {
            var context = new EarthDbEntities();
            using (context)
            {
                int countryId = int.Parse(this.Request.Params["countryId"]);
                var country = context.Countries.Find(countryId);

                if (country != null)
                {
                    string name = this.TextBoxCountryName.Text;
                    string language = this.TextBoxCountryLanguage.Text;
                    int population = int.Parse(this.TextBoxCountryPopulation.Text);

                    country.Name = name;
                    country.Language = language;
                    country.Population = population;

                    context.SaveChanges();

                    Response.Redirect("AppMain.aspx");
                }
            }
        }
    }
}