<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="feedback.aspx.cs" Inherits="Vgrenier.feedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
      <div class="col-md-7 col-lg-5 col-xl-5 offset-xl-3 mt-5" style="border-radius: 3rem; width: 700px;">
        <div class="card bg-glass">
            <div class="card-body px-4 py-3 px-md-5 ">
                <div class="container mt-5 mb-5 " id="wrapper" style="border-radius: 3rem; width: 600px;">
                    <h1>FEEDBACK</h1>

                    <fieldset>
                         <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Name</asp:Label>

                            <asp:TextBox runat="server" ID="txtname"
                                 CssClass="form-control" />

                        </div>
                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Was the Product to your apppeal?</asp:Label>

                            <asp:TextBox runat="server" ID="txttext1"
                                TextMode="Multiline" CssClass="form-control" />


                        </div>


                        <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Do You have any Suggestion?</asp:Label>

                            <asp:TextBox runat="server" ID="txttext2"
                                TextMode="Multiline" CssClass="form-control" />

                        </div>

                         
                          <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Was the website useful to You?</asp:Label>

                            <asp:TextBox runat="server" ID="TextBox2"
                              TextMode="Multiline"   CssClass="form-control" />

                        </div>
                          <div class="mb-3">
                            <asp:Label runat="server"
                                CssClass="form-label">Any more comment</asp:Label>

                            <asp:TextBox runat="server" ID="TextBox3"
                               TextMode="Multiline"  CssClass="form-control" />

                        </div>
                        
                    </fieldset>
 <div class="mb-3">
                        <asp:Button runat="server" Text="Submit"
                            ID="btnRegister" OnClick="btnRegister_Click"
                            CssClass="col-12 btn btn-outline-primary btn-lg" />

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
