<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendNouvelHebergement.aspx.cs" Inherits="MRLoca.BackendNouvelHebergement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
    <h3>Espace Client<em class="lead"> - Nouvel Hébergement</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <div class="form-inline my-1">
            <asp:Label ID="lblNom" runat="server" Text="Titre Annonce : " AssociatedControlID="txtNom" CssClass="col-4"></asp:Label>
            <asp:TextBox CssClass="form-control col-8" ID="txtNom" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Titre Obligatoire" ControlToValidate="txtNom"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline my-1">
            <asp:Label CssClass="col-4" ID="lblDescription" runat="server" Text="Description :" AssociatedControlID="txtDescription"></asp:Label>
            <asp:TextBox CssClass="form-control col-8" ID="txtDescription" runat="server" TextMode="MultiLine" Height="50" ></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Description Obligatoire" ControlToValidate="txtDescription"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline my-1">
            <asp:Label CssClass="col-4" ID="lblType" runat="server" Text="Type de Lgt : " AssociatedControlID="ddlType"></asp:Label>
            <asp:DropDownList CssClass="form-control col-8" ID="ddlType" runat="server"></asp:DropDownList>    
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Type Obligatoire" ControlToValidate="ddlType"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline my-1">
            <asp:Label ID="lblImageErreur" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Label CssClass="col-4" ID="lblPhoto" runat="server" Text="Photo du Lgt : " AssociatedControlID="fudPhoto"></asp:Label>
            <asp:FileUpload CssClass="form-control col=8" ID="fudPhoto" runat="server" />   
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Photo Obligatoire" ControlToValidate="fudPhoto"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline my-1">
            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click"/></div>
    </figure>
</asp:Content>
