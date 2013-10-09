using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationIolitaTeamWork.Models;

namespace WebApplicationIolitaTeamWork.Account
{
    public partial class EditCar : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            int carId = Convert.ToInt32(Request.QueryString["carId"]);
            var context = new SpritEntities();
            var car = context.Cars.Find(carId);

            if (!Page.IsPostBack)
            {
                this.TextBoxEditCarYear.Text = car.Year.Value.Year.ToString();

                if (car.Picture != null)
                {
                    //-<img src='data:image/jpg;base64,<%# Eval("Picture") != null ? Convert.ToBase64String((byte[])Eval("Picture")) : string.Empty %>' alt="image" height="40" width="40" />
                    var imageString = "<img src='data:image/jpg;base64," + Convert.ToBase64String((byte[])car.Picture) + " alt='image' height='40' width='40' />";
                    this.LiteralPicture.Text = imageString;
                }
            }
        }

        protected void ButtonSaveCar_Click(object sender, EventArgs e)
        {   
            int carId = Convert.ToInt32(Request.QueryString["carId"]);

            var context = new SpritEntities();
            try
            {
                DateTime carYear = DateTime.Parse(this.TextBoxEditCarYear.Text + "-01-01");

                byte[] fileData = null;
                Stream fileStream = null;
                int length = 0;

                if (this.FileUploadEditCarPicture.HasFile)
                {
                    var extension = Path.GetExtension(this.FileUploadEditCarPicture.PostedFile.FileName).ToUpper();
                    var imageExtensions = new string[] { ".JPG", ".JPEG", ".GIF", ".PNG" };

                    if (!imageExtensions.Contains(extension))
                    {
                        try
                        {
                            throw new ArgumentOutOfRangeException("Image not in correct format");
                        }
                        catch (Exception ex)
                        {
                            Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                        }

                        return;
                    }

                    length = this.FileUploadEditCarPicture.PostedFile.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = this.FileUploadEditCarPicture.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);

                }

                Car editCar = context.Cars.Find(carId);

                if (this.FileUploadEditCarPicture.HasFile)
                {
                    editCar.Picture = fileData;
                }

                editCar.Year = carYear;

                context.SaveChanges();

                Response.Redirect("~/Account/MyCars.aspx");
            }
            catch (Exception ex)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }
}