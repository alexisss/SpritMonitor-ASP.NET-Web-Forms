using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationIolitaTeamWork.Models
{
    public class FullUserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Bann { get; set; }
        public string Password { get; set; }
    }
}