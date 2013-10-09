using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationIolitaTeamWork;
using WebApplicationIolitaTeamWork.Models;

namespace WebApplicationIolitaTeamWork
{
    public partial class CarDetailsView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new SpritEntities();
            var carId = Convert.ToInt32(Request.Params["carId"]);

            var records = context.Records.Where(c => c.CarId == carId).ToList();

           
        }

        protected void AllCarRecords_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.AllCarRecords.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Record> AllCarRecords_GetData()
        {
            SpritEntities context = new SpritEntities();
            var categories = context.Records.Include("Car").Include("Car.Model").ToList();
            return categories.AsQueryable();

        }
    }
}