<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreerCompte.aspx.cs" Inherits="MRLoca.CreerCompte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
    <div class="form-row">
        <div class="form-inline col-md-12 my-1">
            <label class="col-12 col-sm-12 col-md-2" for="">Nom - Prénom : </label>
            <asp:TextBox ID="txtNom" runat="server" placeholder="Nom" CssClass="form-control col-12 col-sm-12 col-md-4"></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator7" runat="server" ErrorMessage="Nom : Vous devez saisir votre Nom" ControlToValidate="txtNom"></asp:RequiredFieldValidator>
            <asp:TextBox ID="txtPrenom" runat="server" placeholder="Prénom" CssClass="form-control col-12 col-sm-12 col-md-4"></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Prenom : Vous devez saisir votre Prenom" ControlToValidate="txtPrenom"></asp:RequiredFieldValidator>
        </div>
    </div>
    <hr />
    <div class="form-row">
        <div class=" form-inline col-md-6 my-1">
            <label class="col-12 col-sm-12 col-md-4" for="TxtLogin">login : </label>
            <asp:TextBox ID="TxtLogin" runat="server" placeholder="Login" CssClass="form-control col-12 col-sm-12  col-md-8"></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator11" runat="server" ErrorMessage="Prenom : Vous devez saisir votre Login" ControlToValidate="TxtLogin"></asp:RequiredFieldValidator>
        </div>
        <div class=" form-inline col-md-6 my-1">
            <label class="col-6 col-md-3" for="CbxProprietaire">Proprietaire ?</label>
            <asp:CheckBox ID="CbxProprietaire" runat="server" />
        </div>
    </div>
    <div class="form-row">
        <div class="form-inline col-md-12 my-1">
            <label class="col-12 col-sm-12 col-md-2" for="txtEmail1">Email</label>
            <asp:TextBox ID="txtEmail1" runat="server" placeholder="Email" CssClass="form-control col-12 col-sm-12 col-md-4 mr-1"></asp:TextBox>
            <asp:TextBox ID="txtEmail2" runat="server" placeholder="Email" CssClass="form-control col-12 col-sm-12 col-md-4"></asp:TextBox>            
            <%--VALIDATION DES EMAILS - Required + identique + regexp email--%>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Email : Vous devez saisir un Email" ControlToValidate="txtEmail1"></asp:RequiredFieldValidator>
            <asp:CompareValidator Display="None" ID="CompareValidator1" runat="server" ErrorMessage="Email : Les deux Emails doivent être identique" ControlToValidate="txtEmail2" ControlToCompare="txtEmail1"></asp:CompareValidator>
            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email : Incorrect" ControlToValidate="txtEmail1" ValidationExpression="^[^\W][a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\.[a-zA-Z]{2,4}$"></asp:RegularExpressionValidator>
        </div>
        <div class="form-inline col-md-12">
            <label class="col-12 col-sm-12 col-md-2" for="inputPassword4">Password</label>
            <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control col-12 col-sm-12 col-md-4 mr-1" TextMode="Password" placeholder="Password"></asp:TextBox>
            <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control col-12 col-sm-12 col-md-4" TextMode="Password" placeholder="Password"></asp:TextBox>
            <%--Verification des passwords - Required + identique + regexp (8 car. 1 Maj 1 Chiffre 1 car spé ex : !Azerty1 --%> 
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password : Vous devez saisir un mot de passe" ControlToValidate="txtPassword1"></asp:RequiredFieldValidator>
            <asp:CompareValidator Display="None" ID="CompareValidator2" runat="server" ErrorMessage="Password : Les deux Password ne sont pas identique." ControlToValidate="txtPassword2" ControlToCompare="txtPassword1"></asp:CompareValidator>
            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword1"  ErrorMessage="Password : 8 car. min. 1 Maj. 1 Car. Spéc. 1 Chiffre - Ex. : !Azerty1" ValidationExpression="^(?=.*[!@#$%^&*-])(?=.*[0-9])(?=.*[A-Z]).{8,}$"></asp:RegularExpressionValidator>
        </div>
    </div>
    <hr />
    <div class="form-row">
        <div class="form-inline col-12">
            <label class="col-12 col-sm-12 col-md-2" for="txtAdresse">Nom Adresse</label>
            <asp:TextBox ID="TxtNomAdresse" runat="server" CssClass="form-control col-12 col-sm-12 col-md-8" placeholder="Domicile"></asp:TextBox>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator9" runat="server" ErrorMessage="Adresse : Merci de saisir une nom à l'adresse" ControlToValidate="TxtNomAdresse"></asp:RequiredFieldValidator>
        </div>
        <div class="form-inline col-12">
            <label class="col-12 col-sm-12 col-md-2" for="txtAdresse">Adresse</label>
            <asp:TextBox ID="TextNumero" runat="server" CssClass="form-control col-2 col-sm-2 col-md-1" placeholder="10Bis"></asp:TextBox>
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
        <div class="form-inline col-12">
            <label class="col-12 col-sm-12 col-md-2" for="txtVille">Telephone</label>
            <asp:TextBox ID="txtTelephone" runat="server" CssClass="form-control col-12 col-sm-12 col-md-8" placeholder="0102030405"></asp:TextBox>
            <%--Vérification Te - Required + Regexp --%>
            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Telephone : Saisir un numero valide" ControlToValidate="txtTelephone" ValidationExpression="(0|(0033))[1-9][0-9]{8}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator6" runat="server" ErrorMessage="Telephone : Numéro de Telephone Requis" ControlToValidate="txtVille"></asp:RequiredFieldValidator>
        </div>
    </div>
    <hr />
    <div class="text-center"><asp:Button ID="btnValider" runat="server" Text="Valider" CssClass="btn btn-primary" OnClick="btnValider_Click"/></div>
    
</asp:Content>
