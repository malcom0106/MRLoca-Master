<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailHebergement.aspx.cs" Inherits="MRLoca.DetailHebergement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row rounded my-1 p-1 col-12">
        <asp:Image CssClass="img-fluid mx-auto d-block rounded" ID="imgHebergement" runat="server" />
    </div>
    <div class="row my-1 p-0 col-12">
        <div class="rounded col-9">
            <div>
                <h5><asp:Label ID="lblTitre" runat="server" Text=""></asp:Label></h5>
            </div>
            <div>
                <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
            </div>
            <hr />
            <div>
                <h6>Adresse : </h6>
                <asp:Label ID="lblAdresse" runat="server" Text=""></asp:Label>
            </div>
            <asp:Panel ID="panAvis" CssClass="card" runat="server">
                <div class="card-header" id="headingOne">
                    <h2 class="mb-0">
                        <button class="btn btn-link" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            Voir les Avis :
                        </button>
                    </h2>
                </div>
                <div id="collapseOne" class="collapse show" aria-labelledby="headingOne" data-parent="#accordionExample">
                    <asp:ListView ID="lvwAvis" runat="server">
                        <ItemTemplate>
                            <div class="card-body">
                                <div>Note : <%# Eval("Note"); %></div>
                                <div><%# Eval("Commentaire"); %></div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                    
                </div>
            </asp:Panel>            
        </div>
        <div class="border rounded border-info col-3 py-auto ">
            <div class="col-12 text-center py-3">            
                <p>
                    <strong><asp:Label ID="lblPrix" runat="server" Text=""></asp:Label></strong> Eur/jour
                </p>                
            </div>
            <div class="col-12 pb-1">                
                <asp:Button CssClass="btn btn-danger btn-block" ID="btnFavori" runat="server" Text="Favori" OnClick="btnFavori_Click" CommandArgument=""/>
            </div>
            <div class="col-12 pb-1">                
                <asp:Button CssClass="btn btn-info btn-block" ID="btnReserve" runat="server" Text="Réservé" OnClick="btnReserve_Click" CommandArgument=""/>
            </div>
            <div class="col-12">                
                <asp:HyperLink CssClass="btn btn-warning btn-block" ID="lnkRetour" runat="server" NavigateUrl="ListHebergements.aspx">Retour</asp:HyperLink>
            </div>
        </div>

    </div>
</asp:Content>
