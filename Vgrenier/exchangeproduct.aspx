<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="exchangeproduct.aspx.cs" Inherits="Vgrenier.exchangeproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div>
        <h1>
            <asp:Label ID="lblcount" runat="server"></asp:Label></h1>
        <asp:DataList
            ID="dlstproducts"
            RepeatColumns="3" 
            RepeatDirection="Horizontal" 
            runat="server">

            <ItemTemplate>
                <div class="card bg-warning text-white h-100" style="margin: 8px;">
                    <asp:Image runat="server" ImageUrl='<%# Eval("product_image", "~/images/{0}")%>' ID="Image1"
                        CssClass="card-img-top img-fluid" AlternateText="Card image" Width="190px" Height="200px" />
                    <div class="card-body">
                        <h6 class="card-title"><%# Eval("product_name")%></h6>
                        <p class="card-text">
                            by
 <asp:HyperLink CssClass="btn btn-outline-primary stretched-link" Text="Choose Product"
     runat="server" NavigateUrl='<%# Eval("product_id","subscribe.aspx?id={0}")%>'>
 </asp:HyperLink>
                        </p>
                        <p class="card-text">
                            <span><strong>Product Cost:<br />
                            </strong></span><%# Eval("product_cost","{0:c}")%>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
