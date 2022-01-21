<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="TestingWebApp.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1> Employees in our Company  </h1>
            <asp:GridView ID="GridView1" AutoGenerateColumns ="true" runat="server">

            </asp:GridView>
        </div>
    </form>
</body>
</html>
