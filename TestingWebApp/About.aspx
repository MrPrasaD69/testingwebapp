<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TestingWebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%: Title %>.
    
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <asp:Label Text="Name" runat="server"/>
    <asp:TextBox ID="eName" runat="server"></asp:TextBox>

    <asp:Label Text="Lastname" runat="server"/>
    <asp:TextBox ID="eLastname" runat="server"></asp:TextBox>

    <asp:Label Text="Contact" runat="server"/>
    <asp:TextBox ID="eContact" runat="server"></asp:TextBox>

    <asp:Label Text="Save" runat="server"/>
    <asp:Button ID ="SaveBtn" Text="Save" CssClass="btn btn-primary" Width="200px" runat="server" OnClick="SaveBtn_Click" />
</asp:Content>
