﻿<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="unblockuser.aspx.cs" Inherits="Vgrenier.unblockuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
           <style>
 #gvs {
 width:100%;
 }
 th {
 background: #494e5d;
 color: white;
 }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
      <div class="row">
        <div class="col-lg-12">
            <h2>Search and Unblock active users:</h2>
        </div>
    </div>
    <asp:GridView ID="gvs" OnPreRender="gvs_PreRender" HeaderStyle-BackColor="black"
         style="background-color:white" ClientIDMode="Static" CssClass="table table-striped table-bordered"
        runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="user_firstname" HeaderText="First Name" />
            <asp:BoundField DataField="user_lastname" HeaderText="Last Name" />
            <asp:BoundField DataField="user_username" HeaderText="Username" />
            <asp:ImageField DataImageUrlField="user_profilepicture" ControlStyle-Width="50"
                DataImageUrlFormatString="~/images/{0}" HeaderText="imageurl" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <%-- Assign the User_Id to the link button using the CommandArgument --%>
                    <asp:LinkButton ID="lnkunblock" CssClass="btn btn-outline-warning" OnClick="lnkunblock_Click"  CommandArgument='<%# Eval("user_id") %>'
                        runat="server">Unblock</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
