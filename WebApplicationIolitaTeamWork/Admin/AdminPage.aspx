<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebApplicationIolitaTeamWork.Admin.AdminPage" %>
<asp:Content ID="AdminPageContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView 
        runat="server"
         ID="GridViewUsers" 
        ShowFooter="true"
        AllowCustomPaging="true"
         AutoGenerateColumns="false" 
        OnRowEditing="GridViewUsers_RowEditing"
        OnRowUpdating="GridViewUsers_RowUpdating"
        OnRowCancelingEdit="GridViewUsers_RowCancelingEdit"
        ItemType="WebApplicationIolitaTeamWork.Models.FullUserModel"
         DataKeyNames="Id">
         <Columns>
                <asp:TemplateField HeaderText="Operations">
                    <ItemTemplate>
                        <asp:LinkButton ID="UserEdit" runat="server" CausesValidation="false" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:LinkButton ID="UserUpdate" runat="server" CausesValidation="true" CommandName="Update" Text="Update"></asp:LinkButton>
                        <asp:LinkButton ID="UserCancelEdit" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="UserInsert" runat="server" OnClick="UserInsert_Click" CommandName="Insert">Insert</asp:LinkButton>
                        <asp:LinkButton ID="UserInsertCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="User Name" SortExpression="UserName">
                    <ItemTemplate>
                        <asp:Label ID="UsernameField" runat="server" Text="<%#: Item.UserName %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxUserName" runat="server" Text="<%#: Item.UserName %>"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxUserAdd" runat="server" Text="">
                        </asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="User role" SortExpression="Role">
                    <ItemTemplate>
                        <asp:Label ID="LabelRoleText" runat="server" Text='<%#: Item.Role==null ? "User" :Item.Role %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList runat="server" ID="NewUserRoleEdit">
                            <asp:ListItem Text="User"></asp:ListItem>
                            <asp:ListItem Text="Admin"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList runat="server" ID="NewUserRole">
                            <asp:ListItem Text="User"></asp:ListItem>
                            <asp:ListItem Text="Admin"></asp:ListItem>
                        </asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>

             <asp:TemplateField HeaderText="User password" SortExpression="Password">
                    <ItemTemplate>
                        <asp:Label ID="PasswordField" runat="server" Text='<%#: (Item.Password).ToString().Substring(0,10) + "..." %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBoxPassowrd" runat="server" Text="<%#: Item.Password %>"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="TextBoxPasswordAdd" runat="server" Text="">
                        </asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Is Bann" SortExpression="Bann">
                    <ItemTemplate>
                        <asp:Label ID="BannField" runat="server" Text="<%#: Item.Bann %>"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox Checked="false" runat="server" ID="BannCheck"/>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last LastLogin At" SortExpression="LastLogin">
                    <ItemTemplate>
                        <asp:Label ID="LabelLastLogin" runat="server" Text="<%#: Item.LastLogin %>"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
    </asp:GridView>
</asp:Content>
