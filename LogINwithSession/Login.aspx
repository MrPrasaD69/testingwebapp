<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyApp.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        #badgelbl{
            position:relative;
            left:290px;
        }
        #signupbtn{
            
        }
        
    </style>


   
    <div class="container">
      <div class="row">
          <div class="col-md-3">
          </div>
         <div class="col-md-6">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                      
                      </div>

                  
   <%----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                  <div class="row">
                     <div class="col">
                       
                           <span id="badgelbl" class="badge badge-pill badge-info">Login Credentials</span>
                        
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>UserName</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="username" runat="server" placeholder="User name"></asp:TextBox>
                             <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator1" controltovalidate="username" errormessage="Please enter your Username!" />--%>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="password" onkeydown="return nospacetext(event)" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                      <div class="col-md-3">
                      </div>
                             <div class="col-md-6">
                                <div class="form-group">
                                     <asp:Button class="btn btn-success btn-block btn-lg" ID="logbtn" runat="server" Text="Login IN" OnClick="logbtn_Click" />
                                     <a href="SignUp.aspx" id="signupbtn" Class="btn btn-info btn-block btn-lg">Sign UP</a>
                                  </div>
                             </div>
                       <div class="col-md-3">
                       </div>
                  </div>

                 </div>
               </div>
            </div>
          <div class="col-md-3"></div>
                 
         </div>
         
      </div>
        
    <script>
        function nospacetext(x) {
            if (x.keycode == 32) {
                alert("No Space Allowed !");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
