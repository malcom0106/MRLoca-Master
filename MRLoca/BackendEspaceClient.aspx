<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendEspaceClient.aspx.cs" Inherits="MRLoca.BackendEspaceClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Accueil</em></h3>
    <hr />
    <asp:Panel ID="panDefaut" runat="server" CssClass="list-group">
        <a href="BackendCommandes.aspx" class="list-group-item list-group-item-action">Mes Réservation</a>
        <a href="Favoris.aspx" class="list-group-item list-group-item-action">Mes Favoris</a>
        <a href="BackendEditClient.aspx" class="list-group-item list-group-item-action">Information Personnelle</a>
        <a href="BackendMesAdresses.aspx" class="list-group-item list-group-item-action">Mes Adresses</a>
             
    </asp:Panel>
    <asp:Panel ID="panProprio" runat="server">
        <hr />
        <h4>Espace Proprietaire</h4>
        <div Class="list-group">
            <a href="BackendHebergements.aspx" class="list-group-item list-group-item-action">Gérer mes annonces</a>
            <a href="BackendAvis.aspx" class="list-group-item list-group-item-action">Voir les Avis</a>  
            <a href="BackendMessagerie.aspx" class="list-group-item list-group-item-action">Messagerie</a>      
        </div>
    </asp:Panel>
        
</asp:Content>
