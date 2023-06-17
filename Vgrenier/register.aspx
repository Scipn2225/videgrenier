<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Vgrenier.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function validatePassword(source, args) {
            if (args.Value.length >= 7 && args.Value.length <= 12)
                args.IsValid = true;
            else
                args.IsValid = false;
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <section class="reg-bac">
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
                        <h1>Registration</h1>
                        <asp:ValidationSummary ID="ValidationSummary1"
                            HeaderText="Errors in the form are:"
                            ShowMessageBox="true"
                            ShowSummary="true"
                            runat="server" />

                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Title</asp:Label>

                            <div class="form-check-inline">
                                <asp:RadioButton runat="server" ID="rad1" GroupName="sex" />
                                <asp:Label runat="server"
                                    CssClass="form-check-label">Mr</asp:Label>
                            </div>
                            <div class="form-check-inline">
                                <asp:RadioButton runat="server" ID="rad2" GroupName="sex" />
                                <asp:Label runat="server"
                                    CssClass="form-check-label">Mrs</asp:Label>
                            </div>
                            <div class="form-check-inline">
                                <asp:RadioButton runat="server" ID="rad3" GroupName="sex" />
                                <asp:Label runat="server"
                                    CssClass="form-check-label">Miss</asp:Label>
                            </div>
                        </div>
                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">First name</asp:Label>

                            <asp:TextBox runat="server" ID="txtFirstname"
                                CssClass="form-control" />

                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="txtFirstname"
                                CssClass="text-danger"
                                ErrorMessage="The First name field is required." />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Last name</asp:Label>

                            <asp:TextBox runat="server" ID="txtLastname"
                                CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="txtLastname"
                                CssClass="text-danger"
                                ErrorMessage="The Last name field is required." />
                        </div>
                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Contact Number</asp:Label>

                            <asp:TextBox runat="server" ID="txtnumber"
                                CssClass="form-control" />
                        </div>
                        <div class="form">

                            <asp:Label ID="lblCountry" runat="server" Text="District" AssociatedControlID="ddlDistrict"></asp:Label>
                            <div class="div_texbox">
                                <asp:DropDownList ID="ddlDistrict" runat="server"
                                    CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlDistrict" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>

                            </div>

                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Address</asp:Label>

                            <asp:TextBox runat="server" ID="txtaddress"
                                CssClass="form-control" />

                        </div>
                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Email</asp:Label>

                            <asp:TextBox runat="server" ID="txtemail"
                                CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="txtemail"
                                CssClass="text-danger"
                                ErrorMessage="Email field is required." />
                        </div>

                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Date of Birth</asp:Label>
                            <asp:TextBox runat="server" ID="txtdob" TextMode="Date"
                                CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server"
                                ControlToValidate="txtdob"
                                CssClass="text-danger"
                                ErrorMessage="Date Of Birth field is required." />
                        </div>
                        <div class="form">

                            <asp:Label ID="lblUsername" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                            <div class="div_texbox">

                                <asp:TextBox ID="txtUsername" runat="server"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqUsername" ControlToValidate="txtUsername" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                                <asp:RegularExpressionValidator ID="regUsername" ControlToValidate="txtUsername"
                                    ValidationExpression="^[a-zA-Z]{5,}$" runat="server"
                                    ErrorMessage="Username must be minimum 5 characters"></asp:RegularExpressionValidator>


                            </div>

                     <asp:Label ID="lblPassword" runat="server" Text="Password" AssociatedControlID="txtPassword"></asp:Label>
                    <div class="div_texbox">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqPassword" ControlToValidate="txtPassword" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                        <asp:RegularExpressionValidator ID="regPassword" ControlToValidate="txtPassword"
                            ValidationExpression="^(?=.*\d{2})(?=.*[a-zA-Z]{2}).{6,}$" runat="server" ErrorMessage="Password Not Strong"></asp:RegularExpressionValidator>
                        <asp:Label ID="TextBox2_HelpLabel" runat="server" /><br />
                        <br />

                    </div>

                    <asp:Label ID="lblCpassword" runat="server" Text="Confirm Password" AssociatedControlID="txtCpassword"></asp:Label>
                    <div class="div_texbox">
                        <asp:TextBox ID="txtCpassword" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqCpassword" ControlToValidate="txtCpassword" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                      <asp:CompareValidator ID="CompareValidator1" runat="server"
                        ControlToValidate="txtCpassword"
                        ControlToCompare="txtpassword"
                        Operator="Equal"
                        ErrorMessage="Password Does Not Match"></asp:CompareValidator>

                    </div>
                            <div>
                                <asp:Label ID="Label1" runat="server" Text="Upload picture"></asp:Label>
                                <asp:FileUpload ID="FileUpload" runat="server"
                                    CssClass="form-control" />
                            </div>
                            <br />

                            <div class="mb-3">
                                <asp:Button runat="server" Text="Register"
                                    ID="btnRegister" OnClick="btnRegister_Click"
                                    CssClass="col-12 btn btn-outline-success btn-lg" />
                            </div>
                            <div class="mb-3">
                                <asp:LinkButton ID="lnkexit" CssClass="col-12 btn btn-outline-danger btn-lg" OnClick="lnkexit_Click" runat="server">Exit</asp:LinkButton>
                            </div>

                            <div class="mb-3">
                                <asp:LinkButton ID="lnkreset" CssClass="col-12 btn btn-outline-warning btn-lg" OnClick="lnkreset_Click" OnClientClick="return confirm('Are You Sure you wanna clear the form')" runat="server">Reset The Form</asp:LinkButton>
                            </div>
                            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
