<%@ Page Title="Stats" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="WebApplicationIolitaTeamWork.About" %>
<%@ Register Src="~/Controls/MakeModelControl/MakeModels.ascx" 
    TagPrefix="Iolite" TagName="MakeModelSelect" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h1><%: Title %></h1>
    </header>

    <Iolite:MakeModelSelect  ControlLabel="Select car brand:" runat="server" 
           ID="makeModelControl" />
    <asp:Button ID="statsButton" runat="server" Text="Show Record Statistics" OnClick="statsButton_Click" />
    <br />
    <h3>Min Consumption</h3>
    <asp:Label ID="minConsumption" runat="server" />
    <br />
    <h3>Average Consumption</h3>
    <asp:Label ID="avgConsumption" runat="server" />
    <br />
    <h3>Max Consumption</h3>
    <asp:Label ID="maxConsumption" runat="server" />
    <br />
    <h3>Number of Cars</h3>
    <asp:Label ID="carNumber" runat="server" />
    <br />
    <h3>Number of Records</h3>
    <asp:Label ID="recordNumber" runat="server" />
    <br />

</asp:Content>
