<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="postreview.aspx.cs" Inherits="Vgrenier.postreview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .review td, .review th {
            padding: 5px;
            font: 14px Arial,Sans-Serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div>
        <asp:FormView
            ID="frmReview"
            DataSourceID="srcReview"
            DefaultMode="Insert"
            ForeColor="black"
         HeaderStyle-BackColor="White"
            runat="server">
            <InsertItemTemplate>
                <asp:Label
                    ID="lblComment"
                    Text="Enter comments:"
                    AssociatedControlID="txtComment"
                    runat="server" />
                <br />
                <asp:TextBox
                    ID="txtComment"
                    Text='<%# Bind("Comment") %>'
                    TextMode="MultiLine"
                    Columns="50"
                    Rows="4"
                    runat="server" />
                <br />
                <asp:Button
                    ID="btnInsert"
                    Text="Post Review"
                    CommandName="Insert"
                    runat="server" />
            </InsertItemTemplate>
        </asp:FormView>
        <hr />
        <asp:GridView
            ID="gvs"
            DataSourceID="srcReview"
             OnPreRender="gvs_PreRender"
             ClientIDMode="Static"
            CssClass="review"
            runat="server" />
        <%--Invoke the component and the methods GetEntries() and AddEntry() --%>
        <asp:ObjectDataSource
            ID="srcReview"
            OnInserting="srcReview_Inserting"
             TypeName="DataAccessLayer"
             SelectMethod="GetEntries"
             InsertMethod="AddEntry"
            runat="server" />
    </div>
</asp:Content>
