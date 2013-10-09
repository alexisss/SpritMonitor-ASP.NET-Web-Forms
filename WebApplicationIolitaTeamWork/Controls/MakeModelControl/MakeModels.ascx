<%@ Control Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="MakeModels.ascx.cs"
     Inherits="WebApplicationIolitaTeamWork.Controls.MakeModelControl.MakeModels" %>

<asp:Label runat="server" ID="MakesControlLabel" AssociatedControlID="ListBoxMakes" Text='<%#: Eval("ControlLabel") %>'>

</asp:Label>
<br />
<asp:ListBox  id="ListBoxMakes" 
    AutoPostBack="true"
    runat="server"
     OnSelectedIndexChanged="ListBoxMakes_SelectedIndexChanged"
    DataValueField="MakeId" DataTextField="Title">
    
</asp:ListBox>
<br />  
<asp:Label ID="ModeLabel" runat="server" Text="Car makes"></asp:Label>
<br />
<asp:DropDownList id="DropDownModels"
        SelectMethod ="DropDownDataBindGetData"
        DataValueField="ModelId"
        DataTextField="Title" AutoPostBack="true"
        OnSelectedIndexChanged="DropDownModels_SelectedIndexChanged" runat="server" ></asp:DropDownList>
<br />

<asp:GridView runat="server"
        ID="AllCarsFromModel"   
        AllowPaging="True"
        AllowSorting="True"
        AutoGenerateColumns="False"       
        ItemType="WebApplicationIolitaTeamWork.Models.Car"
        DataKeyNames="Id"   
        PageSize="3"
        SelectMethod="AllCarsFromModel_GetData"
        EmptyDataText="No data!">
        <Columns>
            <asp:TemplateField HeaderText="Year" SortExpression="Year">
                <ItemTemplate>
                    <asp:Label ID="Year" runat="server" Text="<%#: Item.Year %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Model">
                <ItemTemplate>
                    <asp:Label ID="Model" runat="server" Text="<%#: Item.Model.Title %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
             <asp:TemplateField HeaderText="User" >
                <ItemTemplate>
                    <asp:Label ID="User" runat="server" Text="<%#: Item.AspNetUser.UserName %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
           <asp:HyperLinkField  DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~/CarDetailsView.aspx?carId={0}" Text="Details" />
        </Columns>
    </asp:GridView>
