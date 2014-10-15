<%@ Page Title="Check Entry" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkEntry.aspx.cs" Inherits="webapp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="CheckEntryValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="CheckEntryValidationGroup"/>

    <h2> Enter check details. All fields are required.
    </h2>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="First Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="firstNameTextBox" 
                             CssClass="failureNotification" ErrorMessage="First name is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text="Last Name:"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="lastNameTextBox" 
                             CssClass="failureNotification" ErrorMessage="Last name is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Address:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="streetNameTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="StreetRequired" runat="server" ControlToValidate="streetNameTextBox" 
                             CssClass="failureNotification" ErrorMessage="Street name is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" Text="City:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="CityRequired" runat="server" ControlToValidate="cityTextBox" 
                             CssClass="failureNotification" ErrorMessage="City name is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label6" runat="server" Text="State:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:TextBox ID="stateTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="StateRequired" runat="server" ControlToValidate="stateTextBox" 
                             CssClass="failureNotification" ErrorMessage="State is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;
    Zip Code:&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
    <asp:TextBox ID="zipTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="ZipRequired" runat="server" ControlToValidate="zipTextBox" 
                             CssClass="failureNotification" ErrorMessage="Zip Code is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" TabIndex="48" Text="Check Value:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="checkValueTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="AmountRequired" runat="server" ControlToValidate="checkvalueTextBox" 
                             CssClass="failureNotification" ErrorMessage="Check value is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label7" runat="server" Text="Routing #"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="routingNoTextBox" runat="server"></asp:TextBox>
                                 
                            <asp:RequiredFieldValidator ID="RoutingNoRequired" runat="server" ControlToValidate="routingNoTextBox" 
                             CssClass="failureNotification" ErrorMessage="Routing number is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" Text="Account #"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="accountNoTextBox" runat="server"></asp:TextBox>
                             
                            <asp:RequiredFieldValidator ID="AccountNoRequired" runat="server" ControlToValidate="accountNoTextBox" 
                             CssClass="failureNotification" ErrorMessage="Account number is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    <br />
    <br />
    <asp:Label ID="Label9" runat="server" Text="Check #"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="checkNoTextBox" runat="server"></asp:TextBox>
                            
                            <asp:RequiredFieldValidator ID="CheckNoRequired" runat="server" ControlToValidate="checkNoTextBox" 
                             CssClass="failureNotification" ErrorMessage="Check number is required." 
                             ValidationGroup="CheckEntryValidationGroup">*</asp:RequiredFieldValidator>
    <br />
    <br />
                    <asp:Button ID="checkEntrySubmitButton" runat="server" CommandName="Submit" Text="Submit Check" 
                        ValidationGroup="CheckEntryValidationGroup" onclick="checkEntrySubmitButton_Click"/>
    <br />
    
</asp:Content>
