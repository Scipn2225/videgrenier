<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="ex5.aspx.cs" Inherits="Vgrenier.Maybe.ex5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .content {
            width: 700px;
            padding: 10px;
            border: solid 1px black;
            background-color: white;
        }

        a {
            color: blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
      <div class="content">
        <!-- This repeater will be used to display list of categories:
change the attributes name and add a query string to pass the Category ID -->
        <asp:Repeater
            ID="rptproductCategories"
            runat="server">
            <ItemTemplate>
                <asp:HyperLink
                    ID="lnkMenu"
                    Text='<%#Eval("cat_name")%>'
                    NavigateUrl='<%#Eval("cat_id","ex5.aspx?id={0}")%>'
                    runat="server" />
            </ItemTemplate>
            <SeparatorTemplate>
                &nbsp;|&nbsp;
            </SeparatorTemplate>
        </asp:Repeater>
        <hr />

        <!-- This DataList will be used to display list of movies depending on which category is selected from
the above Repeater -->
        <asp:DataList
            ID="dlstproductDetails"
            RepeatColumns="1"
            runat="server">
            <ItemTemplate>
                <div class="card bg-warning text-white h-50"
                    style="width: 600px; float: left; margin: 30px;">
                    <asp:Image runat="server" ImageUrl='<%# Eval("product_image", "~/images/{0}")%>'
                        ID="Image1" CssClass="card-img-top mx-auto" Width="190px" Height="200px" />
                    <div class="card-body h">
                        <h2 class="card-title"><%# Eval("product_name")%></h2>
                        <p class="card-text text-dark">
                            Product Description:
                            <%#Eval("product_description") %>
                        </p>
                        <p class="card-text">
                            <span><strong>Product Cost:<br />
                            </strong></span>
                            <span class="text-dark">
                                <%# Eval("product_cost","{0:c}")%>
                            </span>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
</asp:Content>
