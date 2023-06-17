<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="listofproducts.aspx.cs" Inherits="Vgrenier.listofproducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div>
        <h3>List of Products</h3>
        <asp:GridView
            ID="GrdView1"
            AutoGenerateColumns="false"
            OnPageIndexChanging="GrdView1_PageIndexChanging"
            AllowPaging="true"
            PageSize="5"
            HeaderStyle-BackColor="white"
         style="background-color:white"
            CellPadding="30"
            runat="server" >
            <columns>
                <asp:ImageField DataImageUrlField="product_image"
                    DataImageUrlFormatString="~/images/{0}"
                    HeaderText="Image" SortExpression="product_image"
                    ControlStyle-Width="300" />
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <h5>
                            <%# Eval("product_cost" , "{0:c}") %>
                        </h5>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Brand" DataField="product_brand" />
                <asp:HyperLinkField HeaderText="Name" DataTextField="product_name"
                    DataNavigateUrlFields="product_id"
                    DataNavigateUrlFormatString="details.aspx?id={0}" />

            </columns>
            </asp:GridView>
    </div>
</asp:Content>

