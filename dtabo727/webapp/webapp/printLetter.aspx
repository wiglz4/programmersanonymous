<%@ Page Title="Print Letter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="printLetter.aspx.cs" Inherits="webapp.Account.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
   <asp:Label ID="CheckNumberLabel" runat="server" AssociatedControlID="CheckNumber">Check Number:</asp:Label>
   <asp:TextBox ID="CheckNumber" runat="server" CssClass="textEntry" Width="260px"></asp:TextBox>
   <asp:RequiredFieldValidator ID="CheckNumberRequired" runat="server" ControlToValidate="CheckNumber" 
        CssClass="failureNotification" ErrorMessage="Check Number is required." ToolTip="Check Number is required." 
        ValidationGroup="CheckPrintValidationGroup">*</asp:RequiredFieldValidator>
   </p>
   <p>
   <asp:Label ID="LetterNumberLabel" runat="server" AssociatedControlID="LetterNumber">Letter Number:</asp:Label>
   <asp:TextBox ID="LetterNumber" runat="server" CssClass="textEntry" Width="117px"></asp:TextBox>
   <asp:RequiredFieldValidator ID="LetterNumberRequired" runat="server" ControlToValidate="LetterNumber" 
        CssClass="failureNotification" ErrorMessage="Letter Number is required." ToolTip="Letter Number is required." 
        ValidationGroup="CheckPrintValidationGroup">*</asp:RequiredFieldValidator>
   </p>

  <p>
  &nbsp;</p>
    <asp:Button ID="SubmitCheckNumber" runat="server" Text="Print Preview" />
</asp:Content>
