<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendCommandes.aspx.cs" Inherits="MRLoca.BackendCommandes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Réservations</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <asp:ListView ID="lvwHebergement" runat="server">
            <ItemTemplate>                
                <div class="d-flex col-12 border shadow p-3 mb-3 bg-white rounded">                    
                    <div class="col-9 text-left">
                        <div class="">
                            <div class="p-2 bd-highlight text-left">
                                Commande num. : <%# Eval("IdReservation") %>
                            </div>
                            <div><%# Eval("Location.Nom") %></div>
                            <div class="p-2 bd-highlight">Date : <%# Eval("DateDebut") %> au <%# Eval("DateFin") %></div>
                            <%--<div class="p-2 bd-highlight"><%# Eval("Prix") %> Eur/Sem.</div>--%>                        
                            <div id="btns" class="mt-auto p-2 bd-highlight">                            
                            </div>
                        </div>
                    </div>                    
                </div>                               
        </ItemTemplate>
        </asp:ListView>
    </figure>
</asp:Content>
