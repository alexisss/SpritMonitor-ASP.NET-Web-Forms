using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationIolitaTeamWork.Models;

namespace WebApplicationIolitaTeamWork.Controls.MakeModelControl
{
    public partial class MakeModels : System.Web.UI.UserControl
    {
        private string controlLabel;

        public string ControlLabel
        {
            get
            {
                return this.controlLabel;
            }
            set
            {
                this.controlLabel = value;

            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new SpritEntities();
            var makes = context.Makes.ToList();
            this.ListBoxMakes.DataSource = makes;
            this.ListBoxMakes.DataBind();
            this.MakesControlLabel.Text = this.controlLabel;
            this.ListBoxMakes.Items.Insert(0, new ListItem("Select Make", "0"));
            
            if (!Page.IsPostBack)
            {
                this.ListBoxMakes.SelectedIndex = 0;
                ModelBindMakes(Convert.ToInt32(this.ListBoxMakes.SelectedItem.Value));
            }
        }


        protected void ListBoxMakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ViewState["makeId"] = (sender as ListBox).SelectedItem.Value;
            this.ListBoxMakes.SelectedItem.Selected = true;
            var id = Convert.ToInt32((sender as ListBox).SelectedItem.Value);
            ModelBindMakes(id);

        }
        private void ModelBindMakes(int id)
        {
            var context = new SpritEntities();
            var models = context.Models.Where(m => m.MakeId == id).ToList();
            this.DropDownModels.DataSource = models;
            this.DropDownModels.DataBind();
            this.DropDownModels.Items.Insert(0, new ListItem("Select Model", "0"));
        }

        protected void DropDownModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new SpritEntities();

            var id = this.DropDownModels.SelectedIndex;
            var title = this.DropDownModels.SelectedItem.Text;
            this.ViewState["carTitle"] = title;

            this.DropDownDataBindGetData();

            //var cars = context.Cars.Include("AspNetUser").Include("Model").Where(m => m.Model.Title == title).ToList();
            //this.AllCarsFromModel.DataSource = cars;
            //this.AllCarsFromModel.DataBind();
            //Session["ModelId"] = this.DropDownModels.SelectedItem.Value;
        }

        public IQueryable<Model> DropDownDataBindGetData()
        {
            SpritEntities context = new SpritEntities();           
            var categories = context.Models.Include("Make").ToList();
            return categories.AsQueryable();
        }

        protected void AllCarsFromModel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AllCarsFromModel.PageIndex = e.NewPageIndex;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Car> AllCarsFromModel_GetData()
        {
            SpritEntities context = new SpritEntities();
            var cars = context.Cars.Where(m => m.Model.Title == this.ViewState["carTitle"].ToString());
            return cars.AsQueryable();
        }

       
    }
}