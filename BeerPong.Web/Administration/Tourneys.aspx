<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
 
     CodeBehind="Tourneys.aspx.cs" Inherits="BeerPong.Web.Administration.Tourneys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:GridView runat="server" ID="TourneysGridView"
        AutoGenerateColumns="False"
        ItemType="BeerPong.MVP.Tourney.Details.TourneyDetailsViewModel" CssClass="table"
        DeleteMethod="Delete"
        SelectMethod="Select"
        UpdateMethod="Update"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
