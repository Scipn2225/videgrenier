<%@ Page Title="" Language="C#" MasterPageFile="~/dummymaster.Master" AutoEventWireup="true" CodeBehind="viewstats.aspx.cs" Inherits="Vgrenier.viewstats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xl-3 col-md-6">
                <div class="card bg-primary text-white mb-4">
                    <div class="card-body">Products Available:</div>
                    <div class="card-footer d-flex align-items-center justify-contentbetween">
                        <asp:HyperLink ID="hyprod" runat="server" CssClass="small 
text-white stretched-link"></asp:HyperLink>

                        <a class="small text-white stretched-link" href="/listproduct.aspx">View 
Details</a>

                        <div class="small text-white"><i class="fas fa-angleright"></i></div>
                    </div>
                </div>
            </div>



            <div class="col-xl-3 col-md-6">
                <div class="card bg-warning text-white mb-4">
                    <div class="card-body">Users</div>
                    <div class="card-footer d-flex align-items-center justify-contentbetween">
 <asp:HyperLink ID="hyuser" runat="server" CssClass="small 
text-white stretched-link"></asp:HyperLink>
                     
 <a class="small text-white stretched-link" href="/listuser.aspx">View 
Details</a>
                        <div class="small text-white"><i class="fas fa-angleright"></i></div>
                    </div>
                </div>
            </div>
     
            </div>
    </div>
</asp:Content>
