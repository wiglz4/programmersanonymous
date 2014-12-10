<%@ Page Title="Print Letters" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="batchPrintLetter.aspx.cs" Inherits="webapp.Account.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
   <asp:Label ID="LetterNumberLabel" runat="server" AssociatedControlID="LetterNumberDropDownList">Letter Number:</asp:Label>
       <asp:DropDownList ID="LetterNumberDropDownList" runat="server">
           <asp:ListItem>1</asp:ListItem>
           <asp:ListItem>2</asp:ListItem>
           <asp:ListItem>3</asp:ListItem>
       </asp:DropDownList>
   <asp:RequiredFieldValidator ID="LetterNumberRequired" runat="server" ControlToValidate="LetterNumberDropDownList" 
        CssClass="failureNotification" ErrorMessage="Letter Number is required." ToolTip="Letter Number is required." 
        ValidationGroup="CheckPrintValidationGroup">*</asp:RequiredFieldValidator>
   </p>
    <p>

    <asp:Button ID="PrintButton" runat="server" Text="Generate Letters" OnClick="SubmitCheckNumber_Click" style="margin-left: 10px" Width="120px" />

    </p>

    <p>
    <asp:Button ID="viewPDF" runat="server" Text="View PDF" OnClick="ViewPDF" style="margin-left: 10px" Width="120px" />
    </p>

    <br />
    <br />

    
    </asp:Content>
