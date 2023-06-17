<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="ex2.aspx.cs" Inherits="Vgrenier.Maybe.ex2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .content {
            border: solid 3px black;
            background-color: #424242;
            color: white;
        }

        .products {
            width: 700px;
            border-collapse: collapse;
            text-align: justify;
            margin: auto;
        }

            .products th, .products td {
                padding: 20px;
                border-bottom: 1px solid #424242;
            }

        .item {
            background-color: darkorange;
        }

        .alternating {
            background-color: gold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="row">
        <div class="content">
            <asp:GridView
                ID="gvs"
                OnPreRender="gvs_PreRender"
                DataSourceID="srcMovies"
                ClientIDMode="Static"
                runat="server" />
            <asp:ObjectDataSource
                ID="srcMovies"
                TypeName="DataAccessLayer"
                SelectMethod="GetMovies"
                runat="server" />
            <asp:Repeater
                ID="rptproduct"
                runat="server">
                <HeaderTemplate>
                    <table class="products">
                        <tr>
                            <th>Product Title</th>

                            <th>Description</th>
                            <th>Cost</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr class="item">
                        <td><%#Eval("product_name") %></td>
                        <td><%#Eval("product_description") %></td>
                        <td><%#Eval("product_cost","{0:c}") %></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alternating">
                        <td><%#Eval("product_name") %></td>
                        <td><%#Eval("product_description") %></td>
                        <td><%#Eval("product_cost","{0:c}") %></td>
                    </tr>
                </AlternatingItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
