﻿<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="webapp.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        About
    </h2>
    <p>
        Nick Street<br>
        Josh Mangum<br>
        Benji Denning<br>
        John Wiglesworth <br>
        David Tabor<br>
    </p>
</asp:Content>
