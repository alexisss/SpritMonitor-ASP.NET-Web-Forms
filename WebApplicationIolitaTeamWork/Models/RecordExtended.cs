using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationIolitaTeamWork.Models
{
    public class RecordExtended : Record
    {
        private float? gasCost;

        public float? GasCost
        {
            get { 
                this.gasCost = (this.Quantity / this.Distance) * 100;
                return this.gasCost;
            }
            set
            {
                this.gasCost = value;
            }
        }
        
    }
}