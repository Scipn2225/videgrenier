<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="login1.aspx.cs" Inherits="Vgrenier.uc.login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <%@ Register Src="~/uc/logincrtl.ascx" TagPrefix="uc" TagName="Login" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
 <style>
            body {
              background-image: url("../images/m.jpg");
             background-position: center;   
             background-repeat: no-repeat;   
             background-size: cover;  
            }
            
        </style>
    <div class="col-md-7 col-lg-5 col-xl-5 offset-xl-3 mt-5" style="border-radius: 3rem; width: 900px;">
        <div class="card bg-glass">
            <div class="card-body px-4 py-3 px-md-5 ">
                <div class="container mt-5 mb-5 " id="wrapper" style="border-radius: 3rem; width: 800px;">
                    <h1>Login</h1>
                    <div class="form">

                        <uc:Login runat="server" ID="userlogin" ValidationGroup="usergroup" />

                        <br />
                        <br />
                        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" ValidationGroup="usergroup" runat="server"
                            CssClass="btn btn-outline-primary" Text="Log in" />
                    </div>
                    <fieldset>
                        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label><br />
                        <asp:Button ID="btnRegister" runat="server"
                            PostBackUrl="~/register.aspx" Text="Don’t have an account yet? Join now"
                            CausesValidation="false" CssClass="btn btn-outline-warning" /><br />
                    </fieldset>

                </div>
            </div>
        </div>
    </div>

</asp:Content>