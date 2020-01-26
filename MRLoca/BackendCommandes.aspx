<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendCommandes.aspx.cs" Inherits="MRLoca.BackendCommandes" %>
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
                                <button type="button" class="btn btn-primary" onclick="envoisMessage('<%#Eval("Location.Proprietaire.IdClient") %>','','<%#Eval("Location.IdHebergement") %>');" >Repondre</button>
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

    <div class="modal fade" id="ModalRepondre" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Repondre : </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body col-12 ">
                  <asp:TextBox ID="txtdestinataire" runat="server" Visible=""></asp:TextBox>
                  <asp:TextBox ID="txthebergement" runat="server" Visible=""></asp:TextBox>              
                  <asp:TextBox CssClass="form-control col-12" ID="txtSujet" runat="server" Visible=""></asp:TextBox>

              <div class="form-group">
                <label for="message-text" class="col-form-label">Message:</label>
                  <asp:TextBox CssClass="form-control col-12" ID="txtmessage" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
              </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
              <asp:Button ID="btnEnvoyer" CssClass="btn btn-primary" runat="server" Text="Envoyer" OnClick="btnEnvoyer_Click"/>
          </div>
        </div>
      </div>
    </div>
    <script type="text/javascript">
        function envoisMessage(dest,sujet,heb) {
            $('#ModalRepondre').modal('show');
            var txtsujet = '#<%=this.txtSujet.ClientID %>';            
            var txtdes = '#<%=this.txtdestinataire.ClientID %>';
            var txtheberg = '#<%=this.txthebergement.ClientID %>';
            $(txtsujet).val(sujet);

            $(txtdes).val(dest);
            $(txtheberg).val(heb);
        }
    </script>
</asp:Content>
