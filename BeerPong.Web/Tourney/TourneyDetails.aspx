<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourneyDetails.aspx.cs" Inherits="BeerPong.Web.Tourney.TourneyDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 id="TourneyName" runat="server"></h1>

    <asp:Button ID="JoinButton" runat="server" OnClick="JoinButton_Click" Text="Join" />

</asp:Content>
