<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="updateprofile.aspx.cs" Inherits="Vgrenier.uc.updateprofile" %>

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

    <div class="col-md-7 col-lg-5 col-xl-5 offset-xl-3 mt-5" style="border-radius: 3rem; width: 900px;">
        <div class="card bg-glass">
            <div class="card-body px-4 py-3 px-md-5 ">
                <div class="container mt-5 mb-5 " id="wrapper" style="border-radius: 3rem; width: 800px;">
                    <fieldset>
                        <legend>Profile Details</legend>
                        <asp:ValidationSummary ID="ValidationSummary1"
                            HeaderText="Errors in the form are:"
                            ShowMessageBox="true"
                            ShowSummary="true"
                            runat="server" />
                        <asp:Repeater
                            ID="rptimg" runat="server">
                            <ItemTemplate>
                                <asp:Image ID="Label1" runat="server" Width="193px" Height="195px"
                                    ImageUrl='<%# Eval("user_profilepicture", "~/images/{0}")%>' />

                            </ItemTemplate>
                        </asp:Repeater>
                    </fieldset>

                    <div class="form">
                        <asp:Label ID="lblFname" runat="server" Text="First Name:" AssociatedControlID="txtFname"></asp:Label>
                        <div class="div_texbox">
                            <asp:TextBox ID="txtFname" runat="server"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqFname" ControlToValidate="txtFname" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>

                        </div>
                        <asp:Label ID="lblLname" runat="server" Text="Last Name:" AssociatedControlID="txtLname"></asp:Label>
                        <div class="div_texbox">
                            <asp:TextBox ID="txtLname" runat="server"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqLname" ControlToValidate="txtLname" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form">

                            <asp:Label ID="lblUsername" runat="server" Text="Username" AssociatedControlID="txtUsername"></asp:Label>
                        </div>

                        <div class="div_texbox">

                            <asp:TextBox ID="txtUsername" runat="server"
                                CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqUsername" ControlToValidate="txtUsername" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ID="regUsername" ControlToValidate="txtUsername"
                                ValidationExpression="^[a-zA-Z]{5,}$" runat="server"
                                ErrorMessage="Username must be minimum 5 characters"></asp:RegularExpressionValidator>


                        </div>                 

                        <br />
                        <fieldset>
                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server"
                                Text="Update Profile"
                                CssClass="btn btn-outline-primary btn-block" />

                 <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
