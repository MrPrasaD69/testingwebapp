<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendForm.aspx.cs" Inherits="saral.SendForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label runat="server" ID="lblOutput"></asp:Label>
    <asp:HiddenField runat="server" ID="uid" Value="0" />
    <asp:HiddenField runat="server" ID="fid" Value="0" />

    <!DOCTYPE html>
<html lang="en">

<head>
	<title>Document</title>

	<!--jQuery CDN link-->
	<script src="https://code.jquery.com/jquery-3.6.0.min.js"
integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
		crossorigin="anonymous">
	</script>

	<!--jQuery code-->
	<script>
        $(document).ready(function () {
            $("button").click(function () {
                $("p").css("color", "green");
            });
        });
    </script>

	<button>
		Change the color of the text to Green
	</button>
</head>

<body>
	<p>GeeksforGeeks</p>
</body>

</html>


 
</asp:Content>
