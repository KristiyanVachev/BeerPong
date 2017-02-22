<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateTourney.aspx.cs" Inherits="BeerPong.Web.Tourney.CreateTourney" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br>
        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="Name" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="CreateTourney_Click" Text="Create" CssClass="btn btn-default" />
                </div>
            </div>
        </div>

</asp:Content>
