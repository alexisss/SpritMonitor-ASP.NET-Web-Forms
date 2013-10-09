<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCar.aspx.cs" Inherits="WebApplicationIolitaTeamWork.Account.EditCar" %>
<%@ Register Src="~/Controls/MakeModelControl/MakeModels.ascx" TagPrefix="Iolite" TagName="MakeModelSelect" %>

<asp:Content ID="ContentEditCar" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:Label runat="server" AssociatedControlID="TextBoxEditCarYear" Text="Make Year: " ID="LabelEditCarYear" />
    
    <asp:TextBox TextMode="Number" runat="server" ID="TextBoxEditCarYear" />
    <asp:RangeValidator MinimumValue="1974" MaximumValue="2013" ID="RangeValidatorEditYear" ControlToValidate="TextBoxEditCarYear" runat="server" ErrorMessage="Invalid Year" />

    <asp:Label runat="server" Text="Upload Picture: " ID="LabelEditCarPicture" />

    <asp:Literal ID="LiteralPicture" runat="server" />
    <asp:FileUpload runat="server" ID="FileUploadEditCarPicture" />

    <asp:Button ID="ButtonSaveCar" runat="server" Text="Save" OnClick="ButtonSaveCar_Click" />
</asp:Content>
