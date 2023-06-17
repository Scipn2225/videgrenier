<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Vgrenier.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
          <style>

 
#one,#two,#three {
  height: 90%;
  width:  30%;
}

</style>
         <style>
h1 {text-align: center;
    color:red;
}
h2 {text-align: center;
    color:red;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <div class="mt-5">
         <h1>Every Vide Grenier Has A Story</h1>
    <h2>So What's New</h2>
    </div>
   
    <main class="mt-5">
  
        <div class="row form-group" runat="server">
            <div class="col-sm-6 " style="float: left">
                <h3>List of Product</h3>
            </div>
            <div class="col-sm-3" style="float: right;">
                <div class="input-group">
                    <%--Trigger the TextChanged event--%>
                    <asp:DropDownList ID="ddlCategory" OnSelectedIndexChanged="TextBox1_TextChanged" runat="server"
                        CssClass="form-control" AutoPostBack="true">
                    </asp:DropDownList>&nbsp;
                </div>
            </div>
            <div class="col-sm-3" style="float: right;">
                <div class="input-group">
                    <%--generate text changed event--%>
                    <asp:TextBox ID="TextBox1" OnTextChanged="TextBox1_TextChanged" runat="server" AutoPostBack="true" CssClass="form-control" Placeholder="Search..." />
                    <span class="input-group-addon">
                        <i class="fa fa-search"></i></span>
                </div>
            </div>
        </div>

        <%-- START AJAX CONTROL --%>
        <hr />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>

        <contenttemplate>
            <asp:ListView OnPagePropertiesChanging="lvproduct_PagePropertiesChanging"
                ID="lvproduct"
                runat="server" ItemPlaceholderID="itemPlaceholder" DataKeyNames="product_id">


                <ItemTemplate>

                    <div class="card"
                        style="width: 200px; float: left; margin: 8px;">
                        <asp:Image runat="server"
                            ImageUrl='<%# Eval("product_image", "~/images/{0}")%>' ID="Image1"
                            class="card-img-top" alt="Card image" Width="193px" Height="195px" />
                        <div class="card-body">
                            <h6 class="card-title"><%# Eval("product_name")%></h6>
                            <p class="card-text">
                                by 
                        <asp:HyperLink runat="server" NavigateUrl='<%#Eval("product_id","~/productdetails.aspx?id={0}")%>'>
                            <%#Eval("product_status").ToString() +": "+ Eval("product_name").ToString() %>
                        </asp:HyperLink>
                            </p>

                            <p class="card-text">
                                <span><strong>Product Cost:<br />
                                </strong></span><%# Eval("product_cost","{0:c}")%>
                            </p>
                            <%--Eval movie_id as the commandargument--%>
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Request access" CommandName="btnAccess" CommandArgument='<%#Eval("product_id") %>' CssClass="btn btn-primary" OnClick="LinkButton1_Click" />

                        </div>
                    </div>
                </ItemTemplate>
                <LayoutTemplate>
                    <div id="itemPlaceholder" class="categoryContainer" runat="server">
                    </div>
                    <hr style="clear: both" />

                    <div class="text-right">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Link"
                                    ShowNextPageButton="false" ShowFirstPageButton="true" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Link"
                                    ShowPreviousPageButton="false" ShowLastPageButton="true" />
                            </Fields>
                        </asp:DataPager>
                    </div>

                </LayoutTemplate>
            </asp:ListView>
        </contenttemplate>

        <Triggers>

           <asp:AsyncPostBackTrigger ControlID="ddlCategory" EventName="SelectedIndexChanged" />

            <asp:AsyncPostBackTrigger ControlID="TextBox1" EventName="TextChanged" />

        </Triggers>


        <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
    </main>
</asp:Content>
