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
                        <asp:ListView ID="lvwMessage" runat="server" OnPagePropertiesChanging="lvwMessage_PagePropertiesChanging">
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
                                        <button type="button" class="btn btn-primary" onclick="envoisMessage('<%#Eval("IdExpediteur") %>','<%#Eval("Sujet") %>','<%#Eval("Logement.IdHebergement") %>');" >Repondre</button>
                                    
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>                        
                    </table>
                    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvwMessage" PageSize="10">
                            <Fields>
                                <asp:NumericPagerField NumericButtonCssClass="btn btn-secondary" CurrentPageLabelCssClass="btn btn-warning" />
                            </Fields>
                        </asp:DataPager>
                </asp:Panel>
            </div>        
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
              <asp:HiddenField ID="hidDestinataire" runat="server" />
              <asp:HiddenField ID="hidHebergement" runat="server" />
              <asp:HiddenField ID="hidSujet" runat="server" />
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
            var txtsujet = '#<%=this.hidSujet.ClientID %>';            
            var txtdes = '#<%=this.hidDestinataire.ClientID %>';
            var txtheberg = '#<%=this.hidHebergement.ClientID %>';
            $(txtsujet).val(sujet);
            $(txtdes).val(dest);
            $(txtheberg).val(heb);
        }
    </script>
</asp:Content>
