using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebApplicationIolitaTeamWork.Models;
using System.IO;
using System.Text.RegularExpressions;

namespace WebApplicationIolitaTeamWork.Account
{
    public partial class NewCar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSaveCar_Click(object sender, EventArgs e)
        {
            var userId = User.Identity.GetUserId();
            var context = new SpritEntities();
            try
            {
                int modelId = Convert.ToInt32(Session["ModelId"]);
                if (modelId == null || modelId == 0)
                {
                    throw new ArgumentNullException("Plaese select model");
                }

                var model = context.Models.Find(modelId);

                DateTime carYear = DateTime.Parse(this.TextBoxNewCarYear.Text + "-01-01");

                byte[] fileData = null;
                Stream fileStream = null;
                int length = 0;

                if (this.FileUploadNewCarPicture.HasFile)
                {
                    var extension = Path.GetExtension(this.FileUploadNewCarPicture.PostedFile.FileName).ToUpper();
                    var imageExtensions = new string[] { ".JPG", ".JPEG", ".GIF", ".PNG" };

                    if (!imageExtensions.Contains(extension))
                    {
                        Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Required image file");
                    }

                    length = this.FileUploadNewCarPicture.PostedFile.ContentLength;
                    fileData = new byte[length + 1];
                    fileStream = this.FileUploadNewCarPicture.PostedFile.InputStream;
                    fileStream.Read(fileData, 0, length);
                }

                Car newCar = new Car { UserId = userId, Year = carYear, MadelId = modelId, Picture = fileData };

                context.Cars.Add(newCar);
                context.SaveChanges();

                Response.Redirect("~/Account/MyCars.aspx");
            }
            catch(Exception ex)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }
}