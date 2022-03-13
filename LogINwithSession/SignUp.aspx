<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="MyApp.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        
    </style>


   
    <div class="container">
      <div class="row">
         <div class="col-md-8 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="user.jpg"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Member Sign Up</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="eName" runat="server" placeholder="Your Name"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator5" controltovalidate="eName" errormessage="Please enter your Name!" />--%>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Phone No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="ePhone" runat="server" placeholder="Phone No" TextMode="Number"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator4" controltovalidate="ePhone" errormessage="Please enter a Phone Number!" />--%>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Username</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="eUsername" runat="server" ValidationGroup="SignupFrame" placeholder="Choose Username" ></asp:TextBox>
                            <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator3" controltovalidate="eUsername" errormessage="Please enter a new Username!" />--%>
                        </div>
                     </div>
                      <div class="col-md-6">
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox Class="form-control" ID="ePassword" runat="server" placeholder="Choose Password" TextMode="Password" ></asp:TextBox>
                             <%--<asp:RequiredFieldValidator runat="server" id="RequiredFieldValidator2" controltovalidate="ePassword" errormessage="Please enter a new Password!" />--%>
                        </div>
                     </div>
                  </div>

                  <div class="row">
                      <div class="col-md-3">
                       </div>
                      <div class="col-md-6">
                          <div class="form-group">
                             <asp:Button class="btn btn-info btn-block btn-lg" ID="signbtn" runat="server" Text="Sign Up" OnClick="signbtn_Click" />
                             <asp:Button runat="server" ID="updbtn" Text="UPDATE" CssClass="btn btn-warning btn-block btn-lg" OnClick="updbtn_Click"></asp:Button>
                          </div>
                      </div>
                      <div class="col-md-3">
                       </div>
                   </div>
   <%----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------%>
                  <div class="row">
                     <div class="col">
                        <center>
                           <span class="badge badge-pill badge-info">Login Credentials</span>
                        </center>
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
                                  </div>
                             </div>
                       <div class="col-md-3">
                       </div>
                  </div>

                 </div>
               </div>
            </div>
                 <div class="col-md-4">
                  <label>Records Table</label>
                  <div class="row">
                      <asp:GridView runat="server" ID="RecordsTable"></asp:GridView>
                  </div>
                 </div> 
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
