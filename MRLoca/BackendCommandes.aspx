﻿<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendCommandes.aspx.cs" Inherits="MRLoca.BackendCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Espace Client<em class="lead"> - Mes Réservations</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <div class="card-deck col-12">
            <asp:ListView ID="lvwHebergement" runat="server">
                <ItemTemplate>
                    <div class="col-sm-12 col-md-12 col-lg-6">
                        <div class="card">
                            <asp:Image ID="imgLogement" CssClass="card-img-top image-fluid" runat="server" AlternateText="Card image cap" ImageUrl='<%# Eval("Location.Photo") %>' Height="200" />
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Location.Nom") %></h5>
                                <p class="card-text"><%# Eval("Location.Description") %></p> 
                                <p class="card-text">Prix Total : <%# Eval("PrixTotal") %> Eur.</p> 
                            </div>
                            <div class="card-footer">
                                <small class="text-muted">
                                    <p>Du <%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:ddd d MMM yyy}",Eval("DateDebut")) %> </p>
                                    <p>au <%#String.Format(System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"),"{0:ddd d MMM yyy}",Eval("DateDebut")) %> </p>
                                </small>
                            </div>
                            <div class="text-center">
                                <asp:Button ID="btnAnnuler" CssClass="btn btn-danger" CommandArgument='<%# Eval("IdReservation") %>' runat="server" Text="Annuler" OnClick="btnAnnuler_Click"/>
                                <asp:Button ID="btnContact" CssClass="btn btn-primary" CommandArgument='<%# Eval("Location.IdHebergement") %>' runat="server" Text="Contact" OnClick="btnContact_Click" />
                                <asp:Button ID="btnAvis" CssClass="btn btn-warning" CommandArgument='<%# Eval("Location.IdHebergement") %>' runat="server" Text="Ajouter Avis" OnClick="btnAvis_Click" />
                            </div>
                        </div>    
                    </div>                                           
                </ItemTemplate>
            </asp:ListView>
        </div>
    
        <asp:Panel ID="pnlModal" runat="server" Visible="false">
            <div class="jumbotron">
                <h1 class="display-3 text-center">Liste Vide ! </h1>
                <p class="lead text-center">
                    Vous n'avez pas encore commander sur notre plateforme de reservation.<br />
                    <asp:HyperLink ID="lnkHebergement" runat="server" NavigateUrl="ListHebergements.aspx">Cliquez ici</asp:HyperLink> pour vous voir l'ensemble de nos bien en location.
                </p>          
            </div>
        </asp:Panel>
    </figure>
</asp:Content>
