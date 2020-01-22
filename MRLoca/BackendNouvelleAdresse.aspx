<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendNouvelleAdresse.aspx.cs" Inherits="MRLoca.BackendNouvelleAdresse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Espace Client<em class="lead"> - Ajouter une adresse</em></h3>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
    <asp:Label CssClass="label laber-danger" ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">        
        <div class="form-row">
            <div class="form-inline col-12">
                <label class="col-12 col-sm-12 col-md-2" for="txtAdresse">Nom Adresse</label>
                <asp:TextBox ID="TxtNomAdresse" runat="server" CssClass="form-control col-12 col-sm-12 col-md-8" placeholder="Domicile"></asp:TextBox>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Adresse : Merci de saisir une nom à l'adresse" ControlToValidate="TxtNomAdresse"></asp:RequiredFieldValidator>
            </div>
            <div class="form-inline col-12">
                <label class="col-12 col-sm-12 col-md-2" for="txtAdresse">Adresse</label>
                <asp:TextBox ID="TxtNumero" runat="server" CssClass="form-control col-2 col-sm-2 col-md-1" placeholder="10Bis"></asp:TextBox>
                <asp:TextBox ID="txtVoie" runat="server" CssClass="form-control col-10 col-sm-10 col-md-7" placeholder="Rue d'en face"></asp:TextBox>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Adresse : Merci de saisir votre adresse comple" ControlToValidate="txtVoie"></asp:RequiredFieldValidator>
            </div>
            <div class="form-inline col-12">
                <label class="col-12 col-sm-12 col-md-2" for="txtCodePostal">Code Postal -Ville</label>
                <asp:TextBox ID="txtCodePostal" runat="server" CssClass="form-control col-4 col-sm-4 col-md-2" placeholder="CodePostal"></asp:TextBox>
                <%--Vérification CP - Required + Regex pour les CP francais--%>
                <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" runat="server" ErrorMessage="CP : Merci de saisir un CP valide - Ex: 02100 / 2B000" ControlToValidate="txtCodePostal" ValidationExpression="^(([0-8][0-9])|(9[0-5])|(2[ab]))[0-9]{3}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator4" runat="server" ErrorMessage="CP : Code Postal Requis" ControlToValidate="txtCodePostal"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtVille" runat="server" CssClass="form-control col-8 col-sm-8 col-md-6" placeholder="Ville"></asp:TextBox>
                <%--Vérification Ville - Required --%>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Ville : Ville requise" ControlToValidate="txtVille"></asp:RequiredFieldValidator>
            </div> 
               
        </div>
        <div class="col-12 text-center mt-2">
            <asp:Button ID="btnmodifier" CssClass="btn btn-primary" runat="server" Text="Ajouter" OnClick="btnmodifier_Click"/> 
        </div>
    </figure>
</asp:Content>
