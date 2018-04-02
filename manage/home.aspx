<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="manage.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>    
    </div>
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/alterpassword.aspx" >修改密码</asp:LinkButton>
    </form>
</body>
</html>
