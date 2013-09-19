using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileBg
{
    public partial class MainPage : System.Web.UI.Page
    {
        private static List<Model> bmwModels = new List<Model>()
        {
            new Model() { Name = "523" },
            new Model() { Name = "524" },
            new Model() { Name = "525" }
        };

        private static List<Model> fordModels = new List<Model>()
        {
            new Model() { Name = "Mustang" },
            new Model() { Name = "Fiesta" },
            new Model() { Name = "Escort" }
        };

        private static List<Model> opelModels = new List<Model>()
        {
            new Model() { Name = "Insignia" },
            new Model() { Name = "Kadet" },
            new Model() { Name = "Astra" }
        };

        private static List<Brand> brands = new List<Brand>()
        {
            new Brand(0, "BMW", bmwModels),
            new Brand(1, "Ford", fordModels),
            new Brand(2, "Opel", opelModels)
        };

        private static List<Extra> extras = new List<Extra>()
        {
            new Extra("Spoiler"),
            new Extra("Shibidah"),
            new Extra("Nitro")
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // This is not the first load of the page,
                // so we should skip the data binding
                return;
            }

            this.CheckBoxListExtras.DataSource = extras;
            this.CheckBoxListExtras.DataBind();

            this.DropDownBrands.DataSource = brands;
            this.DropDownBrands.DataBind();

            this.DropDownModels.DataSource = brands[0].Models;
            this.DropDownModels.DataBind();
        }

        protected void OnBindModels(object sender, EventArgs e)
        {
            int brandId = int.Parse(this.DropDownBrands.SelectedValue);
            this.DropDownModels.DataSource = brands[brandId].Models;
            this.DropDownModels.DataBind();
        }

        protected void BtnSearchCars_Click(object sender, EventArgs e)
        {
            string brand = this.DropDownBrands.SelectedItem.Text;
            string model = this.DropDownModels.SelectedItem.Text;

            List<string> extras = new List<string>();
            for (int i = 0; i < this.CheckBoxListExtras.Items.Count; i++)
            {
                if (this.CheckBoxListExtras.Items[i].Selected)
                {
                    extras.Add(this.CheckBoxListExtras.Items[i].Text);
                }
            }

            this.LabelChoise.Text = brand + " " + model + ", Extras: ";
            for (int i = 0; i < extras.Count; i++)
            {
                this.LabelChoise.Text += "<strong>" + extras[i] + ", </strong>";
            }
        }
    }
}