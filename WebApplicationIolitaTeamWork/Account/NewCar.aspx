<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewCar.aspx.cs" Inherits="WebApplicationIolitaTeamWork.Account.NewCar" %>
<%@ Register Src="~/Controls/MakeModelControl/MakeModels.ascx" TagPrefix="Iolite" TagName="MakeModelSelect" %>

<asp:Content ID="ContentNewCar" ContentPlaceHolderID="MainContent" runat="server">
    <Iolite:MakeModelSelect  ControlLabel="Select car brand:" runat="server"  ID="makeModelControl"  />

    <asp:Label runat="server" AssociatedControlID="TextBoxNewCarYear" Text="Make Year: " ID="LabelNewCarYear" />
    <asp:TextBox TextMode="Number" Text="1982" runat="server" ID="TextBoxNewCarYear" />
    <asp:RangeValidator MinimumValue="1974" MaximumValue="2013" ID="RangeValidatorEditYear" ControlToValidate="TextBoxNewCarYear" runat="server" ErrorMessage="Invalid Year" />

    <asp:Label runat="server" Text="Upload Picture: " ID="LabelNewCarPicture" />
    <asp:FileUpload runat="server" ID="FileUploadNewCarPicture" />

    <asp:Button ID="ButtonSaveCar" runat="server" Text="Save" OnClick="ButtonSaveCar_Click" />
</asp:Content>
