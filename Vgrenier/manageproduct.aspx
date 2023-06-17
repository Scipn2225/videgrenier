<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="manageproduct.aspx.cs" Inherits="Vgrenier.manageproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="form-horizontal">
        <h4>CRUD Operations to manage product</h4>
        <hr />
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Select
a Category</asp:Label>
            <div class="col-md-8">
                <asp:DropDownList ID="ddlcategory" runat="server"
                    CssClass="form-control">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label"></asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtproductid" Visible="false"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Product
name</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtproductname"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center mt-3">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Brand</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtbrand"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center mt-3">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Product Cost</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtcost"
                    CssClass="form-control" />
            </div>
        </div>
             <div class="form-group row justify-content-center mt-3">
            <asp:Label runat="server" CssClass="col-md-2 col-form-label">Expiry Date</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtexp"
                    CssClass="form-control" TextMode="Date"/>
        </div>
        <div class="form-group row justify-content-center mt-3">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Description</asp:Label>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="txtdesc" TextMode="Multiline"
                    CssClass="form-control" />
            </div>
        </div>
        <div class="form-group row justify-content-center mt-3">
            <asp:Label runat="server"
                CssClass="col-md-2 col-form-label">Poster</asp:Label>
            <div class="col-md-8">
                <asp:FileUpload ID="fuposter" runat="server" CssClass="" />
                <asp:Image ID="Image1" runat="server" Visible="false" Width="75"
                    Height="100" />
            </div>
        </div>

    </div>
    <div class="form-group row justify-content-center">
        <asp:Label runat="server"
            CssClass="col-md-2 col-form-label"></asp:Label>
        <div class="col-md-8">
            <div class="form-check-inline">
                <asp:CheckBox runat="server" ID="chkstatus"
                    CssClass="form-check-input" />
                <asp:Label runat="server"
                    CssClass="form-check-label">Status</asp:Label>
            </div>
        </div>
    </div>

    <div class="form-group row justify-content-center">
        <div class="offset-md-2 col-md-8">
          
            <asp:Button runat="server" ID="btnupdate" OnClick="btnupdate_Click" Text="Update Product"
                Visible="false" CssClass="btn btn-block btn-outline-primary" />
            <asp:Button runat="server" ID="btndelete" OnClick="btndelete_Click" OnClientClick="return confirm ('Are you sure you want to delete?')" Text="Delete Product"
                Visible="false" CssClass="btn btn-block btn-outline-primary" />
            <asp:Button runat="server" ID="btncancel" OnClick="btncancel_Click" Text="Cancel"
                Visible="false" CssClass="btn btn-block btn-outline-primary" />
            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        </div>
    </div>
    <hr />
    <asp:GridView ID="gvs" AutoGenerateColumns="false" DataKeyNames="product_id" OnSelectedIndexChanged="gvs_SelectedIndexChanged" ClientIDMode="Static"
        Width="800" runat="server">
        <HeaderStyle BackColor="Yellow" ForeColor="Black" Font-Bold="true"
            Height="30" />

        <RowStyle BackColor="Green" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSelect" runat="server" ForeColor="Black"
                        CssClass="btn btn-outline-info " CommandName="Select" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField FooterStyle-BackColor="Black" HeaderText="Product Name">
                <ItemTemplate>
                    <!-- display the movie name -->
                    <asp:Label ID="lblproductname" Text='<%#Eval("product_name")%>'
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <%-- add an imagefield here to display the poster--%>
        </Columns>
    </asp:GridView>
</asp:Content>

