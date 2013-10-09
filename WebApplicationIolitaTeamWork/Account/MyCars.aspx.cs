using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using WebApplicationIolitaTeamWork.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace WebApplicationIolitaTeamWork
{
    public partial class Contact : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable GridViewMyCars_GetData()
        {
            var userId = User.Identity.GetUserId();
            var context = new SpritEntities();

            var myCars = context.Cars.Include("Model").Include("Model.Make").Where(c => c.UserId == userId);
            return myCars;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyCars_UpdateItem(int id)
        {
            var context = new SpritEntities();
            var carToEdit = context.Cars.Find(id);
            TryUpdateModel(carToEdit);
            if (ModelState.IsValid)
            {
                context.Entry(carToEdit).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewMyCars_DeleteItem(int id)
        {
            var context = new SpritEntities();
            var carToRemove = context.Cars.Find(id);

            try
            {
                var records = carToRemove.Records;
                context.Records.RemoveRange(records);
                context.Cars.Remove(carToRemove);

                context.SaveChanges();
                this.GridViewMyCars.DataBind();

                Error_Handler_Control.ErrorSuccessNotifier.AddSuccessMessage("Car removed");
            }
            catch (Exception ex)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }

        public void GridViewMyCars_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddRecord")
            {
                this.AddRecordPanel.Visible = true;
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewRecords_UpdateItem(int recordId)
        {
            var context = new SpritEntities();
            WebApplicationIolitaTeamWork.Models.Record recordToEdit = context.Records.Find(recordId);

            TryUpdateModel(recordToEdit);

            if (ModelState.IsValid)
            {
                context.Entry(recordToEdit).State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewRecords_DeleteItem(int id)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<RecordExtended> GridViewRecords_GetData([Control("GridViewMyCars")]int? carId)
        {
            if (this.GridViewMyCars.SelectedDataKey != null)
            {
                int selectedCarId = Convert.ToInt32(carId);

                var context = new SpritEntities();
                var selectedCarRecords = context.Records
                    .Where(r => r.CarId == selectedCarId)
                    .Select(r => new RecordExtended
                    {
                        Date = r.Date,
                        Distance = r.Distance,
                        Quantity = r.Quantity,
                        RecordId = r.RecordId,
                        Car = r.Car,
                        CarId = r.CarId,
                        GasCost = (r.Quantity / r.Distance) * 100
                    });


                return selectedCarRecords.OrderBy(r => r.RecordId);
            }

            return null;
        }

        protected void ButtonAddNewRecord_Click(object sender, EventArgs e)
        {
            this.AddRecordPanel.Visible = true;
        }

        protected void ButtonSaveRecord_Click(object sender, EventArgs e)
        {
            int selectedCarId = Convert.ToInt32(this.GridViewMyCars.SelectedDataKey.Value);

            var context = new SpritEntities();

            int distance = int.Parse(this.TextBoxRecordDistance.Text);
            int quantity = int.Parse(this.TextBoxRecordQuantity.Text);

            Record newRecord = new Record { Date = DateTime.Now, Distance = distance, Quantity = quantity };
            Car selectedCar = context.Cars.Find(selectedCarId);

            context.Records.Add(newRecord);
            selectedCar.Records.Add(newRecord);

            context.SaveChanges();

            this.AddRecordPanel.Visible = false;
            this.GridViewRecords.DataBind();
        }

    }
}