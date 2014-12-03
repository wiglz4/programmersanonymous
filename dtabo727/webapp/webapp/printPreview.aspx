<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printPreview.aspx.cs" title="Print Preview" Inherits="webapp.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body onload="window.print()">
    <form id="form1" runat="server">
        <img src="/ImageResources/header.jpg" alt="Bounce House"/>
    
    <div>
        <%:Session["letterHeading"]%>
        <br/>
        <br/>
        <%:Session["letterBody"]%>
        <br/>
        <br/>
        <%:Session["letterClose"]%>
        <br/>
        <br/>
        <%:Session["letterSig"]%>
    </div>
        <p>
            &nbsp;</p>
        <p>
          <!--<a href="javascript:window.print()"> <img src="/ImageResources/printButton.png" border="0"  height="85" width="85" title="Print Page"/> </a> -->
        </p>
    </form>
</body>
</html>
