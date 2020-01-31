<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendMessagerie.aspx.cs" Inherits="MRLoca.BackendMessagerie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h3>Espace Client<em class="lead"> - Messagerie</em></h3>

            <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
                <asp:Literal ID="MaMessagerie" runat="server"></asp:Literal>
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
