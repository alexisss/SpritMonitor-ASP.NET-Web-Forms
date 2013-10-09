<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplicationIolitaTeamWork._Default" %>

   <%@ Register Src="~/Controls/MakeModelControl/MakeModels.ascx" 
    TagPrefix="Iolite" TagName="MakeModelSelect" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      <Iolite:MakeModelSelect  ControlLabel="Select car brand:" runat="server" 
           ID="makeModelControl" />        
</asp:Content>