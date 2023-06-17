<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="Vgrenier.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div>
        <asp:Label ID="lblMsg" runat="server" Text=" " CssClass="textsuccess"></asp:Label>
        <hr />
        <asp:HyperLink ID="HyperLink1"
            NavigateUrl="viewusers.aspx" runat="server">View
Users</asp:HyperLink>
        <h4>Add, Update, Delete Records using a GridView</h4>
        <asp:Label ID="Label1" runat="server" Text=" "></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblcatid" runat="server" Text="Category
ID"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryId" runat="server" CssClass="formcontrol" Enabled="false" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblcname" runat="server" Text="Category
Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCategoryName" runat="server"
                        CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCategoryName"
                        runat="server" Text="*"
                        ControlToValidate="txtCategoryName" ForeColor="Red"
                        ValidationGroup="vgAdd" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" OnClick="btnInsert_Click" runat="server"
                        Text="Insert" ValidationGroup="vgAdd" CssClass="btn btnoutline-primary" />
                    <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server"
                        Text="Update" ValidationGroup="vgAdd" CssClass="btn btnoutline-warning" />
                    <asp:Button ID="btnDelete" OnClick="btnDelete_Click"  runat="server" CssClass="btn btnoutline-danger" OnClientClick="return confirm('Are you sure you want to
delete this record?')"
                        Text="Delete" ValidationGroup="vgAdd" />
                    <asp:Button ID="btnCancel" OnClick="btnCancel_Click" runat="server"
                        Text="Cancel" CausesValidation="false" CssClass="btn btnoutline-success" />
                </td>
            </tr>
        </table>
        <br />
        <!-- set the primary for the category table as the DataKeynames-->
        <asp:GridView ID="gvs" DataKeyNames="cat_id"
             OnSelectedIndexChanged="gvs_SelectedIndexChanged"
            AutoGenerateColumns="false"
            Width="500" runat="server">
            <HeaderStyle BackColor="#9a9a9a" ForeColor="White"  Height="30" />
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server" CssClass="btn
btn-outline-info"
                            CommandName="Select" Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Name">
                    <ItemTemplate>
                        <!-- display the category name -->
                        <asp:Label ID="lblCatName" Text='<%#Eval("Cat_name")%>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

