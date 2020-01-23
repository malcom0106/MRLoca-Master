<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendCommandes.aspx.cs" Inherits="MRLoca.BackendCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Réservations</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <div class="card-deck col-12">
            <asp:ListView ID="lvwHebergement" runat="server">
                <ItemTemplate>
                    <div class="col-sm-12 col-md-12 col-lg-6">
                        <div class="card">
                            <img class="card-img-top" src='<%# Eval("Location.Photo") %>' alt="Card image cap">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Location.Nom") %></h5>
                                <p class="card-text"><%# Eval("Location.Description") %></p>                            
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
    </figure>
</asp:Content>
