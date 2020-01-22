<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendMessagerie.aspx.cs" Inherits="MRLoca.BackendMessagerie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Messagerie</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <div class="row col-12">
            <div class="col-2">
                <div class="col-12">
                    <asp:Button ID="btn_tous" CssClass="btn btn-secondary col-12" runat="server" Text="Tous" OnClick="btn_tous_Click"/>
                </div>
                <div class="col-12">
                    <asp:Button ID="btn_recus" CssClass="btn btn-secondary col-12" runat="server" Text="Reçus" OnClick="btn_recus_Click"/>
                </div>
                <div class="col-12">
                    <asp:Button ID="btn_envoyes" CssClass="btn btn-secondary col-12" runat="server" Text="Envoyés" OnClick="btn_envoyes_Click"/>
                </div>
            </div>
            <asp:Panel ID="panListeMessage" runat="server" CssClass="col-10">
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>

                <%--Mes Messages--%>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Exp.</th>
                            <th>Dest.</th>
                            <th>Date</th>
                            <th>Message</th>
                            <th></th>
                        </tr>
                    </thead>                
                    <asp:ListView ID="lvwMessage" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("Expediteur.Nom") %></td>
                                <td><%#Eval("Destinataire.Nom") %></td>
                                <td><%#Eval("DateMessage") %></td>
                                <td>
                                    <p><em><%#Eval("Sujet") %></em></p>
                                    <p><strong><%#Eval("Logement.Nom") %></strong> </p>
                                    <p><%#Eval("LeMessage") %></p>
                                </td>
                                <td>
                                    <asp:Button ID="btnEnvoi" CssClass="btn btn-primary col-12" runat="server" Text="Envoyé" CommandName='<%# Eval("IdExpediteur") %>' CommandArgument='<%# Eval("IdDestinataire") %>' OnClick="btnEnvoi_Click"/>
                                    <asp:Button ID="btnSupprime" CssClass="btn btn-danger col-12" runat="server" Text="Supprimé" CommandArgument='<%# Eval("IdMessagerie") %>' OnClick="btnSupprime_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>


<%--                <asp:GridView ID="gvwListeMessage" AutoGenerateColumns="false" runat="server" CssClass="table table-bordered table-stripped">
                    <Columns>                        
                        <asp:BoundField DataField="Expediteur.Nom" HeaderText="A: / De :"/>
                        <asp:BoundField DataField="DateMessage" HeaderText="Date d'envoi"/>
                        <asp:BoundField DataField="LeMessage" HeaderText="Message"/>                        
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button ID="btnEnvoi" CssClass="btn btn-primary col-12" runat="server" Text="Envoyé" CommandName='<%# Eval("IdExpediteur") %>' CommandArgument='<%# Eval("IdDestinataire") %>' OnClick=""/>
                                <asp:Button ID="btnSupprime" CssClass="btn btn-danger col-12" runat="server" Text="Supprimé" CommandArgument='<%# Eval("IdMessagerie") %>' OnClick="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>--%>
            </asp:Panel>
        </div>        
    </figure>
</asp:Content>
