<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        #logoutbtn{
            float:right;
            width: 10px;
        }
    </style>
    <div class="jumbotron">
        <label runat="server" id="namelbl" visible="false"></label>
        <asp:Button runat="server" ID="logoutbtn" Text="LOG OUT" OnClick="logoutbtn_Click" CssClass="btn btn-danger" Visible="false"></asp:Button>
        
            <label runat="server" id="unamelbl" visible="false"></label>
            <label runat="server" id="pidlbl" visible="false"></label>
        
    </div>

    

</asp:Content>
