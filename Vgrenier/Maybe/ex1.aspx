<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="ex1.aspx.cs" Inherits="Vgrenier.Maybe.ex1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .content {
            width: 1100px;
            border: solid 1px black;
            background-color: #eeeeee;
            margin: auto;
        }

        .movies {
            margin: 20px 10px;
            padding: 10px;
            border: dashed 2px black;
            background-color: white;
            overflow: hidden;
        }

        .box1 {
            float: left;
            max-width: 540px;
            margin-right: 50px;
            text-align: justify;
            font-style: italic;
            min-height: 300px;
        }

        .box2 {
            margin-top: 2px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
       <div class="row">
            <div class="content">
                <asp:Repeater
                    ID="rptproduct"
                    runat="server">
                    <ItemTemplate>
                        <div class="products">
                            <div class="box1">
                                <h1><%#Eval("product_name") %></h1>
                                <b>Product Description:</b> <%# Eval("product_description") %>
                                <br />
                            </div>
                            <div>
                                <asp:Image ID="imgposter" ImageUrl='<%# Eval("product_image", "~/images/{0}") %>'
                                    CssClass="img-fluid" Width="170" runat="server" />
                                <div class="box2">
                                    <asp:LinkButton PostBackUrl='<%# Eval("product_id", "rating.aspx?={0}") %>' ID="lnkprodetails" runat="server" Text="Choose Product"                  CssClass="btn btn-info"></asp:LinkButton>
                                </div>
                            </div>
                            <div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
</asp:Content>
