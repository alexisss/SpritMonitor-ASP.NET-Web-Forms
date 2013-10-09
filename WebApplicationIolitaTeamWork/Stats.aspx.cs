using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationIolitaTeamWork.Models;

namespace WebApplicationIolitaTeamWork
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void statsButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["ModelId"] == null)
                {
                    Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(new ArgumentNullException().Message);
                }

                int id = Convert.ToInt32(Session["ModelId"]);
                var context = new SpritEntities();
                var cars = context.Cars.Where(x => x.MadelId == id);
                var statistics = new Statistic()
                {
                    Min = int.MaxValue,
                    Avg = 0,
                    Max = 0,
                    Count = 0,
                    Records = 0
                };

                foreach (var item in cars)
                {
                    double min = (double)item.Records.Min(x => x.Quantity / x.Distance);
                    double avg = (double)item.Records.Average(x => x.Quantity / x.Distance);
                    double max = (double)item.Records.Max(x => x.Quantity / x.Distance);
                    if (statistics.Min > min)
                    {
                        statistics.Min = min;
                    }

                    statistics.Avg += avg;

                    if (statistics.Max < max)
                    {
                        statistics.Max = max;
                    }

                    statistics.Count++;
                    statistics.Records += item.Records.Count;
                }

                statistics.Avg /= statistics.Count;

                this.minConsumption.Text = string.Format("{0:F4} Litters per 100 Kilometer", statistics.Min * 100);
                this.avgConsumption.Text = string.Format("{0:F4} Litters per 100 Kilometer", statistics.Avg * 100);
                this.maxConsumption.Text = string.Format("{0:F4} Litters per 100 Kilometer", statistics.Max * 100);
                this.carNumber.Text = statistics.Count.ToString();
                this.recordNumber.Text = statistics.Records.ToString();
            }
            catch(Exception ex)
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }

    public class Statistic
    {
        public double Min { get; set; }
        public double Avg { get; set; }
        public double Max { get; set; }
        public int Count { get; set; }
        public int Records { get; set; }
    }
}