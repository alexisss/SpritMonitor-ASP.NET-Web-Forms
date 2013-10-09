<%@ Page Title="My Cars" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyCars.aspx.cs" Inherits="WebApplicationIolitaTeamWork.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewMyCars" runat="server" CssClass="table table-bordered " 
        ItemType="WebApplicationIolitaTeamWork.Models.Car"
        DataKeyNames="Id"
        SelectMethod="GridViewMyCars_GetData"
        UpdateMethod="GridViewMyCars_UpdateItem"
        DeleteMethod="GridViewMyCars_DeleteItem"
        OnRowCommand="GridViewMyCars_RowCommand"
        AutoGenerateColumns="false"
        ShowFooter="true">
        <Columns>
             <asp:TemplateField>
                <HeaderTemplate>Picture</HeaderTemplate>
                <ItemTemplate>
                    <img src='data:image/jpg;base64,<%# Eval("Picture") != null ? Convert.ToBase64String((byte[])Eval("Picture")) : string.Empty %>'
                        alt="image" height="40" width="40" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Model.Make.Title" HeaderText="Make" />
            <asp:BoundField DataField="Model.Title" HeaderText="Model" />
            <asp:BoundField DataField="Year.Year" HeaderText="Year" />
            <asp:HyperLinkField DataNavigateUrlFields="Id" ControlStyle-CssClass="btn btn-xs btn-default" DataNavigateUrlFormatString="~/Account/EditCar.aspx?carId={0}" Text="edit" />
            
            <asp:CommandField HeaderText="Actions" ControlStyle-CssClass="btn btn-xs btn-default"
                ShowDeleteButton="true" DeleteText="del"
                ShowSelectButton="true" SelectText="show records" />
            
        </Columns>
    </asp:GridView>
    <asp:HyperLink NavigateUrl="~/Account/NewCar.aspx" runat="server" Text="Add New Car" CssClass="btn btn-primary" />

    <asp:GridView ID="GridViewRecords" runat="server" CssClass="table table-bordered"
        AutoGenerateColumns="false" ShowFooter="true"
        ItemType="WebApplicationIolitaTeamWork.Models.RecordExtended"
        AllowPaging="true" PageSize="5"
        AllowSorting="true"
        DataKeyNames="RecordId"
        SelectMethod="GridViewRecords_GetData"
        UpdateMethod="GridViewRecords_UpdateItem"
        DeleteMethod="GridViewRecords_DeleteItem">
        
        <Columns>
            <asp:TemplateField HeaderText="Distance" SortExpression="Distance">
                <ItemTemplate>
                    <asp:Label runat="server" ID="LabelRecordsDistance" Text="<%#: Item.Distance %>" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxRecordsDistanceEdit" runat="server" Text="<%#: BindItem.Distance %>" />
                </EditItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                <ItemTemplate>
                    <asp:Label runat="server" ID="LabelRecordsQuantity" Text="<%#: Item.Quantity %> "/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxRecordsQuantityEdit" runat="server" Text='<%# BindItem.Quantity %>' />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Cost">
                <ItemTemplate>
                    <asp:Label runat="server" ID="LabelRecordsCost" Text="<%#: Item.GasCost %> "/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button runat="server" ID="ButtonRecordsEdit" CommandName="Edit" CssClass="btn btn-xs btn-default" Text="Edit" />
                    <asp:Button runat="server" ID="ButtonRecordsRemove" CommandName="Remove" CssClass="btn btn-xs btn-default" Text="Del" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Button runat="server" ID="ButtonRecordsUpdate" CommandName="Update" CssClass="btn btn-xs btn-default" Text="Save" />
                    <asp:Button runat="server" ID="ButtonRecordsEditCancel" CommandArgument="Cancel" CssClass="btn btn-xs btn-default" Text="Cancel" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="ButtonAddNewRecord" runat="server" Text="Add Record" CssClass="btn btn-primary" OnClick="ButtonAddNewRecord_Click" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Panel ID="AddRecordPanel" runat="server" Visible="false">
        <asp:Label Text="Distance" runat="server" />
        <asp:TextBox runat="server" ID="TextBoxRecordDistance" />

        <asp:Label Text="Quantity" runat="server" />
        <asp:TextBox runat="server" ID="TextBoxRecordQuantity" />

        <asp:Button ID="ButtonSaveRecord" runat="server" Text="Save" OnClick="ButtonSaveRecord_Click" CssClass="btn btn-default" />
    </asp:Panel>
</asp:Content>
