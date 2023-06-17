<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="listuser.aspx.cs" Inherits="Vgrenier.listuser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    
    <asp:GridView ID="gvs" runat="server"
        onPreRender="gvs_PreRender"
        DataSourceID="srcUsers"
        ClientIDMode="Static"
        AutoGenerateColumns="False" ForeColor="black"
         HeaderStyle-BackColor="LightPink"
         style="background-color:brown">
         
        <Columns>
            <asp:ImageField DataImageUrlField="user_profilepicture"
                DataImageUrlFormatString="~/images/{0}" HeaderText="Poster" ControlStyle-Width="50px"
                SortExpression="Poster" />
            <asp:BoundField DataField="user_username" HeaderText="Username"
                SortExpression="username" />
            <asp:BoundField DataField="user_status" HeaderText="Status"
                SortExpression="Status" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource
            ID="srcUsers"
            runat="server"
            TypeName="DataAccessLayer"
            SelectMethod="GetUsers"
            />
</asp:Content>
