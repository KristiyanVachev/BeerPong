<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourneyDetails.aspx.cs" Inherits="BeerPong.Web.Tourney.TourneyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 id="TourneyName" runat="server"></h1>
    <h2>Status: <span id="TourneyStatus" runat="server">Open</span></h2>

    <div id="OnOpenEvent" runat="server" visible="False">
        <asp:Button ID="JoinButton" runat="server" OnClick="JoinButton_Click" Text="Join" />
    </div>

    <div id="OwnerOptions" runat="server" visible="False">

        <div id="EndTourney" runat="server">
            <asp:DropDownList ID="PlayersDropDown" runat="server"
            AutoPostBack="True"
            EnableViewState="True"
            SelectMethod="BindPlayers"
            CssClass="category-dropdown">
        </asp:DropDownList>

            <asp:Button ID="EndTourneyButton" runat="server" OnClick="EndTourneyButton_Click" Text="End Tourney" />
        </div>

    </div>

</asp:Content>
