<%@ Page Title="Query checks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="checkQuery.aspx.cs" Inherits="webapp.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <!-- hidden panel pops up when check is selected -->

    <asp:Panel ID="PnlMain" runat="server" Width="921px" Height="300px" Visible ="false">
          <p>
             &nbsp;</p>
        <asp:GridView ID="GridView2" autogeneratecolumns="true" runat="server" HorizontalAlign="Center" BackColor="White">
        </asp:GridView>
          <p>
            &nbsp;</p>
        <div style="text-align:center">
            <asp:Button ID="PrintButton" Text="Print" OnClick="Print_Click" runat="server"/>
            <asp:Button ID="EditButton" Text="Edit" OnClick="Edit_Click" runat="server"/>
            <asp:Button ID="DeleteButton" Text="Delete" OnClick="Delete_Click" runat="server"/>
            <asp:Button ID="CancelButton" Text="Cancel" OnClick="Cancel_Click" runat="server"/>
        </div>
        <p> </p>

        <!-- test -->
        <asp:Label ID="Label1" runat="server" Text="Account ID:" Visible ="false"></asp:Label>
        <asp:TextBox ID="AccID" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>

        <asp:Label ID="Label3" runat="server" Text="Amount Paid:" Visible ="false"></asp:Label>
        <asp:TextBox ID="AmtPaid" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>

        <asp:Label ID="Label4" runat="server" Text="Amount Due:" Visible ="false"></asp:Label>
        <asp:TextBox ID="AmtDue" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>

        <p> </p>
        <asp:Label ID="Label5" runat="server" Text="Check No:" Visible ="false"></asp:Label>
        <asp:TextBox ID="CheckNo" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>

        <asp:Label ID="Label6" runat="server" Text="Letter Sent No:" Visible ="false"></asp:Label>
        <asp:TextBox ID="LetterNo" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>

        <asp:Label ID="Label7" runat="server" Text="Check Date:" Visible ="false"></asp:Label>
        <asp:TextBox ID="CheckDate" runat="server" CssClass="textEntry" Visible ="false"></asp:TextBox>
        <p> </p>
        <div style="text-align:right">
            <asp:Button ID="SaveButton" Text="Save" OnClick="Save_Click" runat="server" Visible ="false"/>
        </div>
         <!-- test -->

    </asp:Panel>

     <!--hidden panel pops up when check is selected -->

   <asp:Label ID="CheckNumberLabel" runat="server" AssociatedControlID="CheckNumber">Check Number:</asp:Label>
   <asp:TextBox ID="CheckNumber" runat="server" CssClass="textEntry"></asp:TextBox>
   <asp:RequiredFieldValidator ID="CheckNumberRequired" runat="server" ControlToValidate="CheckNumber" 
        CssClass="failureNotification" ErrorMessage="Check Number is required." ToolTip="Check Number is required." 
        ValidationGroup="CheckQueryValidationGroup">*</asp:RequiredFieldValidator>

    <asp:Button ID="QueryCheckNumber" Text="Retrieve Check" OnClick="QueryBtn_Click" runat="server"/>


  <p>
      &nbsp;</p>
    <asp:Label ID="Label2" runat="server" Text="Select a record below to print, modify, or remove check from database."></asp:Label>
    <p> </p>
    <asp:GridView ID="myGridView" autogeneratecolumns="true" 
        runat="server">
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
    </asp:GridView>

</asp:Content>