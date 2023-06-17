<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="advancesearch.aspx.cs" Inherits="Vgrenier.advancesearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
     <div>
        <h3>Search for Products by Total Cost and Name </h3>
        <h4>Filter by Cost:</h4>
        <asp:DropDownList ID="ddlcost" AutoPostBack="true" OnSelectedIndexChanged="txtproductname_TextChanged" runat="server" CssClass="form-control">
        <asp:ListItem Text="Select Amount" Value="-1"></asp:ListItem>
            <asp:ListItem Text="Above $15000" Value="15000"></asp:ListItem>
            <asp:ListItem Text="Above $30000" Value="30000"></asp:ListItem>
            <asp:ListItem Text="Above $500000" Value="500000"></asp:ListItem>
        </asp:DropDownList>
        <br />
        <h4>Enter Product name</h4>
        <asp:TextBox ID="txtproductname" AutoPostBack="true" CssClass="form-control"
            runat="server" OnTextChanged="txtproductname_TextChanged"></asp:TextBox>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

            <ContentTemplate>
                 <asp:DataList
            ID="dlstproduct"
            runat="server">
            <ItemTemplate>
                <h1><%#Eval("product_name")%></h1>
                Product Description:
                <%#Eval("product_description") %>
                <br />
                Total Cost:
                <%#Eval("product_cost","{0:c}") %>
            </ItemTemplate>
        </asp:DataList>

                </ContentTemplate>

            <Triggers>

                <asp:AsyncPostBackTrigger ControlID="ddlcost" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtproductname" EventName="TextChanged" />
            </Triggers>

        </asp:UpdatePanel>
       
    </div>
</asp:Content>
