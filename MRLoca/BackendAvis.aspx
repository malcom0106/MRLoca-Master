<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendAvis.aspx.cs" Inherits="MRLoca.BackendAvis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Mes Avis</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <div class="accordion" id="accordionExample">
            <asp:Literal ID="litAvis" runat="server"></asp:Literal>
        </div>
    </figure>
</asp:Content>
