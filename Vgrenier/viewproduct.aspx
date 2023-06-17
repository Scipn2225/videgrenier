<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="viewproduct.aspx.cs" Inherits="Vgrenier.viewproduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
 .floater {
 float: left;
 border: solid 1px black;
 padding: 5px;
 margin: 5px;
 }
 </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
      <div>

    <div class="container" style="margin-top:70px ;">
 <h1>List of availabe Products: </h1>
 <asp:BulletedList
 ID="BulletedList1"
 runat="server">
 </asp:BulletedList>
 </div>
                 </div>
</asp:Content>
