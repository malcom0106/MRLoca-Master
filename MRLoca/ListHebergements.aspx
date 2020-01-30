<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListHebergements.aspx.cs" Inherits="MRLoca.ListHebergements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><asp:Literal ID="litTitre" runat="server"></asp:Literal></h2>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <asp:Panel ID="pnlModal" runat="server" Visible="false">
        <div class="jumbotron">
            <h3 class="display-4 text-center">Aucun Logement ! </h3>
            <p class="lead text-center">
                Malheureusement, Nous ne proposons pas encore de logement correspondant à votre demande.<br />
                <asp:LinkButton ID="lnkTousLgt" runat="server" OnClick="lnkTousLgt_Click">Cliquez ici</asp:LinkButton> pour voir ensemble de nos hebergements.
            </p>          
        </div>
    </asp:Panel>
    <asp:ListView ID="lsvHebergement" runat="server" OnPagePropertiesChanging="lsvHebergement_PagePropertiesChanging">
        <ItemTemplate>
            <div class="d-flex col-12 border shadow p-3 mb-3 bg-white rounded">
                <div class="col-3 text-right">
                    <a href="#" data-toggle="modal" data-target="#ModalPhoto" onclick='<%# Eval("Photo","changerImage(\"imgModal\",\"{0}\");") %>'><asp:Image ID="Image1" CssClass="img-fluid" runat="server" ImageUrl='<%# Eval("Photo") %>'/></a>
                </div>
                <div class="col-9 text-left">
                    <div class="d-flex align-items-end flex-column bd-highlight mb-3">
                        <div class="p-2 bd-highlight">
                            <asp:LinkButton ID="lbtDetail" runat="server" CommandArgument='<%# Eval("IdHebergement") %>' OnClick="lbtDetail_Click"><%# Eval("Nom") %></asp:LinkButton>
                            <asp:Literal ID="litNote" runat="server"></asp:Literal>
                        </div>
                        <div class="p-2 bd-highlight"><%# Eval("Description") %></div>
                        <div class="p-2 bd-highlight"><%# String.Format("{0:f2}", Eval("PrixDeBase"))%> Eur/Jour</div>                
                        <div id="btns" class="mt-auto p-2 bd-highlight">
                            <asp:Button CssClass="btn btn-success" ID="btnFavori" runat="server" Text="Favori" CommandArgument='<%# Eval("IdHebergement") %>' OnClick="btnFavori_Click" />
                            <asp:Button CssClass="btn btn-primary" ID="btnreserve" runat="server" Text="Reservé" CommandArgument='<%# Eval("IdHebergement") %>' OnClick="btnreserve_Click"/>

                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lsvHebergement" PageSize="6">
        <Fields>
            <asp:NumericPagerField NumericButtonCssClass="btn btn-secondary" CurrentPageLabelCssClass="btn btn-warning"/>
        </Fields>
    </asp:DataPager>
   <%-- Modal pour affichage de l'image en plus grand--%>
    <div class="modal" tabindex="-1" role="dialog" id="ModalPhoto">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body"><img src="#" id="imgModal"/></div>
        </div>
      </div>
    </div>  


    <%--Script JS pour changement Image--%>
    <script type="text/javascript">        
        function changerImage(img, src) {            
            var image = new Image();
            var largeurModal = 466;
            var reduction = 1;

            image.onerror = function () {
                alert("Erreur lors du chargement de l'image");
            }

            image.onabort = function () {
                alert("Chargement interrompu");
            }

            // une fois l'image chargée :
            image.onload = function () {
                // si l'image est désignée par son id
                if (typeof img == "string")
                    img = document.getElementById(img);

               
                // on affiche l'image
                reduction = image.width / largeurModal
                img.src = image.src;
                img.width = largeurModal;
                img.height = Math.round(image.height / reduction);
            }
            image.src = src;            
        }
    </script>
</asp:Content>
