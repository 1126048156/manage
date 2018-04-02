<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="enter.aspx.cs" Inherits="manage.enter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        账 号 ：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="账号不能为空" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
    
    </div>
        <p>
            密 码 ：<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        </p>
        <p>
            验证码：<asp:TextBox ID="TextBox3" runat="server" Width="95px"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/code.aspx"  />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="验证码不能为空" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        </p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="登录" Width="101px" OnClick="Button1_Click" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/enroll.aspx">注册</asp:LinkButton>
&nbsp;&nbsp;
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/resetpassword.aspx">忘记密码</asp:LinkButton>
    </form>
</body>
</html>
