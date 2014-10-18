﻿<%@ Page Title="Query checks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkQuery.aspx.cs" Inherits="webapp.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Label ID="CheckNumberLabel" runat="server" AssociatedControlID="CheckNumber">Check Number:</asp:Label>
   <asp:TextBox ID="CheckNumber" runat="server" CssClass="textEntry"></asp:TextBox>
   <asp:RequiredFieldValidator ID="CheckNumberRequired" runat="server" ControlToValidate="CheckNumber" 
        CssClass="failureNotification" ErrorMessage="Check Number is required." ToolTip="Check Number is required." 
        ValidationGroup="CheckQueryValidationGroup">*</asp:RequiredFieldValidator>
   
   
  <p>
      &nbsp;</p>

    <asp:Button ID="QueryCheckNumber" runat="server" Text="Retrieve Check" />
  <p>
      &nbsp;</p>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server">Query results show here</asp:PlaceHolder>

</asp:Content>