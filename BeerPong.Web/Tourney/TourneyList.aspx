<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TourneyList.aspx.cs" Inherits="BeerPong.Web.Tourney.TourneyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">

        <asp:UpdatePanel runat="server">

            <ContentTemplate>
                <asp:GridView runat="server" ID="ProductList" AutoGenerateColumns="False"
                    ItemType="BeerPong.MVP.Tourney.Details.TourneyDetailsViewModel"
                    DataKeyNames="Id"
                    CssClass="productsGrid" BorderColor="White" BorderStyle="None"
                    SelectMethod="Select"
                    BorderWidth="0"
                    CellPadding="30"
                    GridLines="Horizontal">
                    <RowStyle CssClass="grid-row" VerticalAlign="Top" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="round-corners">
                                    <asp:Label Text='<%# Eval("Name") %>' runat="server" CssClass="product-name" />
                                    <asp:Label Text='<%# $"Status: {Eval("Status")}" %>' runat="server" CssClass="product-category" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
