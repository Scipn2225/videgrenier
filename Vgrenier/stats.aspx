<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="Vgrenier.stats" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

        <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>


    <ajaxToolkit:PieChart ID="PieChart1" runat="server"></ajaxToolkit:PieChart>

</asp:Content>
