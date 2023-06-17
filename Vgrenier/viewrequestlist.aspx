<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="viewrequestlist.aspx.cs" Inherits="Vgrenier.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container py-5 mb-5">
        <div class="text-center">
            <h1>My Request</h1>
            <div class="content">
                <asp:Repeater ID="rptProduct"
                    runat="server">
                    <ItemTemplate>
                        <section>
                            <div class="container py-5">
                                <div class="row justify-content-center">
                                    <div class="col-md-8 col-lg-6 col-xl-4">
                                        <div class="card" style="border-radius: 15px; width: 300px;">
                                            <div>
                                                <asp:Image ID="imgposter" ImageUrl='<%# Eval("Product_image", "../images/{0}") %>'
                                                    CssClass="img-fluid" Width="200" runat="server" />
                                            </div>
                                            <div class="bg-image hover-overlay ripple ripple-surface ripple-surface-light"
                                                data-mdb-ripple-color="light">

                                                <div class="card-body pb-0">

                                                    <div class="d-flex justify-content-between">

                                                        <div class="text-center">

                                                            <p class="text-muted">Product Name</p>
                                                            <h1><%#Eval("Product_name") %></h1>
                                                            <p class="text-muted">Price</p>
                                                            <h4 class="mb-3"><%#Eval("Product_cost") %></h4>
                                                            <p class="text-muted">Request Date</p>
                                                            <h4 class="mb-3"><%# Eval("AccessDate") %>
                                                            </p>
                                                            <p class="text-muted">Status</p>
                                                            <h4 class="mb-3"><%# Eval("Status") %>
                                                            </p>
                                                        </div>

                                                    </div>
                                                </div>
                                            </div>
                                            <div>
                                                <%--<p class="text-muted mb-2"> Requested By <span class="fw-bold text-body">1222528743</span></p>--%>
                                                <p class="text-muted mb-4">Order By</p>
                                                <h1><%#Eval("user_id") %></h1>
                                            </div>
                                            <div>
                                                <asp:HyperLink runat="server" NavigateUrl='<%#Eval("product_id","~/productdetails.aspx?id={0}")%>'>
                            <%#Eval("product_brand").ToString() +": "+ Eval("product_name").ToString() %>
                                                </asp:HyperLink>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>

                        </section>
                    </ItemTemplate>

                </asp:Repeater>

            </div>
        </div>

    </div>
    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>

</asp:Content>
