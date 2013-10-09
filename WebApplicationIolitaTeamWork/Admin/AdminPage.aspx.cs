using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplicationIolitaTeamWork.Account;
using WebApplicationIolitaTeamWork.Models;

namespace WebApplicationIolitaTeamWork.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new SpritEntities();
            AspNetUser user = new AspNetUser();

            var all = (from u in context.AspNetUsers.Include("AspNetUserManagement").Include("AspNetRoles")
                       join secrets in context.AspNetUserSecrets
                       on u.UserName equals secrets.UserName
                       select new FullUserModel
                       {
                           Id=u.Id,
                           UserName=u.UserName,
                           Password=secrets.Secret,
                           Role = (from r in u.AspNetRoles
                                  select r.Name).FirstOrDefault(),
                           LastLogin=  u.AspNetUserManagement.LastSignInTimeUtc,
                           Bann=u.AspNetUserManagement.DisableSignIn
                       }).ToList();

            //var allUsers = context.AspNetUsers.Include("AspNetUserManagement")
            //    .Include("AspNetRoles").ToList();
            this.GridViewUsers.DataSource = all;
            this.GridViewUsers.DataBind();
        }

        protected void GridViewUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var id = (string)(this.GridViewUsers.DataKeys[e.RowIndex].Value);
            var context = new SpritEntities();
            var user = context.AspNetUsers.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                throw new ArgumentException("There is no such todo in the db (with same id)");
            }
            GridViewRow row = this.GridViewUsers.Rows[e.RowIndex];

            string userRole = ((DropDownList)row.FindControl("NewUserRoleEdit")).SelectedItem.Text;
            bool isBann = ((CheckBox)row.FindControl("BannCheck")).Checked;

            //Response.Write(isBann.ToString());
            //Response.Write(userRole.ToString());
            if (userRole=="Admin")
            {
                context.AspNetRoles.FirstOrDefault(r => r.Id == "1").AspNetUsers.Add(user);
            }
            else
            {
                context.AspNetRoles.FirstOrDefault(r => r.Id == "1").AspNetUsers.Remove(user);
            }

            AspNetUserManagement bann = context.AspNetUserManagements.FirstOrDefault(m => m.UserId == user.Id);
            bann.DisableSignIn = isBann;
            context.Entry(bann).State = EntityState.Modified;
            context.SaveChanges();
            this.GridViewUsers.DataBind();

        }

        protected void UserInsert_Click(object sender, EventArgs e)
        {
            string userName = (this.GridViewUsers.FooterRow.Cells[1].Controls[1] as TextBox).Text;
            string pass = (this.GridViewUsers.FooterRow.Cells[3].Controls[1] as TextBox).Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore());
            User u = new User(userName) { UserName = userName };
            IdentityResult result = manager.Users.CreateLocalUser(u, pass);
            if (result.Success)
            {
                this.GridViewUsers.DataBind();
            }
            else
            {
                Response.Write("Stana greshka");
             //   ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
            
        }

        protected void GridViewUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridViewUsers.DataBind();
        }
    }
}