<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendHebergements.aspx.cs" Inherits="MRLoca.BackendHebergements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Hebergements</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <asp:ListView ID="lvwHebergement" runat="server">
            <ItemTemplate>                
                <div class="d-flex col-12 border shadow p-3 mb-3 bg-white rounded">
                    <div class="col-3 text-right">
                        <asp:Image ID="Image" CssClass="img-fluid" runat="server" ImageUrl='<%# Eval("Photo") %>'/>
                    </div>
                    <div class="col-9 text-left">
                        <div class="d-flex align-items-end flex-column bd-highlight mb-3">
                            <div class="p-2 bd-highlight">
                                <h3><%# Eval("Nom") %></h3>
                            </div>
                            <div class="p-2 bd-highlight"><%# Eval("Description") %></div>
                            <%--<div class="p-2 bd-highlight"><%# Eval("Prix") %> Eur/Sem.</div>--%>                        
                            <div id="btns" class="mt-auto p-2 bd-highlight">                            
                            </div>
                        </div>
                       <%-- <div class="col-12 text-center">
                            <asp:Button ID="btnEdit" runat="server" Text="Modifier" CommandArgument='<%# Eval("IdHebergement") %>' CssClass="btn btn-secondary" OnClick="btnEdit_Click"/>
                        </div>--%>
                    </div>                    
                </div>                               
        </ItemTemplate>
        </asp:ListView>        
        <div class="text-center">
            <asp:Button ID="btnNouveauLgt" runat="server" Text="Nouveau Lgt" CssClass="btn btn-primary" OnClick="btnNouveauLgt_Click"/>
        </div>
    </figure>
</asp:Content>
