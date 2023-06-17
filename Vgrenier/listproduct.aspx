<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="listproduct.aspx.cs" Inherits="Vgrenier.listproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div>
<asp:GridView
ID="gvs"
     OnPreRender="gvs_PreRender"
DataSourceID="srcMovies"
ClientIDMode="Static"
HeaderStyle-BackColor="black"
 style="background-color:white"  
runat="server" />
<asp:ObjectDataSource
ID="srcMovies"
     TypeName="DataAccessLayer"
     SelectMethod="GetMovies"
runat="server" />
</div>
</asp:Content>
