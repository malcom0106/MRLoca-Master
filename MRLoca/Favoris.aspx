<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="Favoris.aspx.cs" Inherits="MRLoca.Favoris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Favoris</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <asp:GridView ID="gvwFavoris" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-striped mt-3">
        <HeaderStyle CssClass="" />
        <Columns>
            <asp:BoundField DataField="Nom" HeaderText="Nom"/>
            <asp:BoundField DataField="Type" HeaderText="Type"/>
            <asp:TemplateField HeaderText="Supprimer">
                <ItemTemplate>
                    <asp:Button CssClass="btn btn-danger" ID="btnSupprimer" runat="server" Text="Supprimer" CommandArgument='<%# Eval("IdHebergement") %>' OnClick="btnSupprimer_Click" OnClientClick="return FireConfirm();"/>
                    <asp:Button CssClass="btn btn-primary" ID="btnReserve" runat="server" Text="Reservé" CommandArgument='<%# Eval("IdHebergement") %>' OnClick="btnReserve_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <%--Modal en cas de favori NULL--%>
    <asp:Panel ID="pnlModal" runat="server" Visible="false">
        <div class="jumbotron">
            <h1 class="display-3 text-center">Liste Vide ! </h1>
            <p class="lead text-center">
                Votre liste de favoris est vide. Nous vous invitons à rejoindre la liste des hébergement afin de faire  votre choix.<br />
                <asp:HyperLink ID="lnkHebergement" runat="server" NavigateUrl="ListHebergements.aspx">Cliquez ici</asp:HyperLink> pour vous y rendre plus rapidement.
            </p>          
        </div>
    </asp:Panel>
    </figure>
    <script type="text/javascript">
        function FireConfirm() {
            if (confirm('Vous êtes sur le point de supprimer votre favori. Etes vous sur ? '))
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
