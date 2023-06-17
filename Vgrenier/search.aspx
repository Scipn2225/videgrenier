<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Vgrenier.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div style="margin-top:50px ;">
        <asp:Label ID="Label1" runat="server" Text="Search Product by id:"></asp:Label>

    <asp:TextBox ID="txtproductid" runat="server" AutoPostBack="true" OnTextChanged="txtproductid_TextChanged" ></asp:TextBox>

    <asp:GridView ID="gvs" runat="server"></asp:GridView>
    </div>
    
</asp:Content>
