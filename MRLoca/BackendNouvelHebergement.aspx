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
                <asp:Label CssClass="col-4" ID="Label1" runat="server" Text="Prix de Base : " AssociatedControlID="txtPrixDeBase"></asp:Label>
                <asp:TextBox ID="txtPrixDeBase" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator5" runat="server" ErrorMessage="Prix de base Obligatoire" ControlToValidate="txtPrixDeBase"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="YourRegularExpressionValidator" 
                                    ControlToValidate="txtPrixDeBase" 
                                    runat="server"
                                    ErrorMessage="Saissir un prix valide"
                                    EnableClientScript="false"  
                                    ValidationExpression="^\d+([,\.]\d{1,2})?$"
                                    Display="Dynamic">
                </asp:RegularExpressionValidator>
            </div>
            <div class="form-inline my-1">
                <asp:Label ID="lblImageErreur" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label CssClass="col-4" ID="lblPhoto" runat="server" Text="Photo du Lgt : " AssociatedControlID="fudPhoto"></asp:Label>
                <asp:FileUpload CssClass="form-control col=8" ID="fudPhoto" runat="server" />   
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Photo Obligatoire" ControlToValidate="fudPhoto"></asp:RequiredFieldValidator>
            </div>
        <hr />
        <div class="form-row">            
            <div class="form-inline col-12">
                <label class="col-12 col-sm-12 col-md-2" for="txtAdresse">Adresse</label>
                <asp:TextBox ID="TxtNumero" runat="server" CssClass="form-control col-2 col-sm-2 col-md-1" placeholder="10Bis"></asp:TextBox>
                <asp:TextBox ID="txtVoie" runat="server" CssClass="form-control col-10 col-sm-10 col-md-7" placeholder="Rue d'en face"></asp:TextBox>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Adresse : Merci de saisir votre adresse comple" ControlToValidate="txtVoie"></asp:RequiredFieldValidator>
            </div>
            <div class="form-inline col-12">
                <label class="col-12 col-sm-12 col-md-2" for="txtCodePostal">Code Postal -Ville</label>
                <asp:TextBox ID="txtCodePostal" runat="server" CssClass="form-control col-4 col-sm-4 col-md-2" placeholder="CodePostal"></asp:TextBox>
                <%--Vérification CP - Required + Regex pour les CP francais--%>
                <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator3" runat="server" ErrorMessage="CP : Merci de saisir un CP valide - Ex: 02100 / 2B000" ControlToValidate="txtCodePostal" ValidationExpression="^(([0-8][0-9])|(9[0-5])|(2[ab]))[0-9]{3}$"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator7" runat="server" ErrorMessage="CP : Code Postal Requis" ControlToValidate="txtCodePostal"></asp:RequiredFieldValidator>
                <asp:TextBox ID="txtVille" runat="server" CssClass="form-control col-8 col-sm-8 col-md-6" placeholder="Ville"></asp:TextBox>
                <%--Vérification Ville - Required --%>
                <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Ville : Ville requise" ControlToValidate="txtVille"></asp:RequiredFieldValidator>
            </div> 
        </div>
        <div class="form-inline my-1">
            <asp:Button ID="btnAjouter" runat="server" Text="Ajouter" OnClick="btnAjouter_Click"/></div>
    </figure>
</asp:Content>
