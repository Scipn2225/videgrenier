<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="productdetails.aspx.cs" Inherits="Vgrenier.productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <h1 style="text-align:center;">Product details</h1>
    <div class="d-flex align-items-center justify-content-center">

     <asp:DetailsView ID="DetailsView1" runat="server" 
         AlternatingRowStyle-BackColor="White" BackColor="White" AutoGenerateRows="false">

        <Fields>

            <asp:ImageField ControlStyle-Height="500px" DataImageUrlField="product_image"
                DataImageUrlFormatString="../images/{0}"
                SortExpression="Product image" />

            <asp:TemplateField>

                <ItemTemplate>
                    <h5><strong><em>
                        <%# Eval("product_name") %>
                    </em></strong></h5>
                    <br />
                    <%# Eval("product_description") %>
                </ItemTemplate>

            </asp:TemplateField>

            <asp:CheckBoxField DataField="product_status" />

            <asp:ButtonField DataTextField="product_name" ControlStyle-CssClass="btn btn-outline-success" />

        </Fields>

    </asp:DetailsView>
        </div>

</asp:Content>
