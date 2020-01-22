<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendMesAdresses.aspx.cs" Inherits="MRLoca.BackendMesAdresses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Adresses</em></h3>
    <figure class="row figure bg-white py-2 col-12 border shadow my-3 bg-white rounded text-center">        
        <asp:ListView ID="lstAdresse" runat="server">
            <ItemTemplate>
                <div class="card col-5 m-1">                  
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nom") %></h5>
                        <p class="card-text"><%# Eval("Numero") %>  <%# Eval("Voie") %><br />
                            <%# Eval("CodePostal") %> <%# Eval("Ville") %>
                        </p>      
                        <div class="col-12 text-center">
                            <asp:Button ID="btnModifier" CssClass="btn btn-primary col-5 text-center" runat="server" Text="Editer" CommandArgument='<%# Eval("IdAdresse") %>' OnClick="btnModifier_Click" />
                            <asp:Button ID="btnsupprimer" runat="server" CssClass="btn btn-danger col-5 text-center" Text="Suppr." CommandArgument='<%# Eval("IdAdresse") %>' OnClick="btnsupprimer_Click" OnClientClick="return FireConfirm()"/>
                        </div>

                    </div>
                </div>                
            </ItemTemplate>            
        </asp:ListView>
        <div class="col-12 text-center mt-2">
                    <asp:HyperLink ID="btnNewAddress" runat="server" CssClass="btn btn-primary" NavigateUrl="BackendNouvelleAdresse.aspx">Ajouter une Adresse</asp:HyperLink>
        </div>
    </figure>

        <script type="text/javascript">
        function FireConfirm() {
            if (confirm('Vous êtes sur le point de vous déconnecter. Etes vous sur ? '))
                return true;
            else
                return false;
        }
    </script>

</asp:Content>
