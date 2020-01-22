<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendNouveauMessage.aspx.cs" Inherits="MRLoca.BackendNouveauMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h3>Espace Client<em class="lead"> - Nouveau Message à : <asp:Label ID="lblDestinataire" runat="server" Text="IciNomPersonne"></asp:Label></em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
          <asp:TextBox CssClass="col-12" ID="txtmessage" runat="server" TextMode="MultiLine" Height="400"></asp:TextBox>
        <div class="col-12 text-center">
            <asp:Button ID="btnEnvoye" runat="server" Text="Envoyez" OnClick="btnEnvoye_Click" CssClass="btn btn-primary col-4 "/></div>
    </figure>
</asp:Content>
