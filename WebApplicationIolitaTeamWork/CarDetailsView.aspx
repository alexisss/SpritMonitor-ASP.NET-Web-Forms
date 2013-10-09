<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="CarDetailsView.aspx.cs" 
    Inherits="WebApplicationIolitaTeamWork.CarDetailsView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <asp:GridView runat="server"
        ID="AllCarRecords"   
        AllowPaging="True"
        AllowSorting="True"
        AutoGenerateColumns="False"       
        ItemType="WebApplicationIolitaTeamWork.Models.Record"
        DataKeyNames="RecordId"   
        PageSize="5"
        SelectMethod="AllCarRecords_GetData"       
        EmptyDataText="No data!">
        <Columns>
            <asp:TemplateField HeaderText="Date" SortExpression="Date">
                <ItemTemplate>
                    <asp:Label ID="Data" runat="server" Text="<%#: Item.Date %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Distance" SortExpression="Distance">
                <ItemTemplate>
                    <asp:Label ID="Distance" runat="server" Text="<%#: Item.Distance %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label ID="Quantity" runat="server" Text="<%#: Item.Quantity%>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Car" SortExpression="CarId">
                <ItemTemplate>
                    <asp:Label ID="Car" runat="server" Text="<%#: Item.Car.Model.Title %>"></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
