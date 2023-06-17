<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="searchuser.aspx.cs" Inherits="Vgrenier.searchuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
        <div style="margin-top:50px ;">
        <asp:Label ID="Label1" runat="server" Text="Search User by Name:"></asp:Label>

    <asp:TextBox ID="txtuserid" runat="server" AutoPostBack="true" OnTextChanged="txtproductid_TextChanged" ></asp:TextBox>

    <asp:GridView ID="gvs" runat="server"></asp:GridView>
    </div>
</asp:Content>
