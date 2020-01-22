<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendEditClient.aspx.cs" Inherits="MRLoca.BackendEditClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
    <h3>Espace Client<em class="lead"> - Mes informations personnelles</em></h3>
    <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
        
        <div class="form-inline Text-Center mt-3">
            <div class="form-group col-12 col-lg-6">
                <label for="txtNom" class="col-md-12 col-lg-4">Nom : </label>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-8" ID="txtNom" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-12 col-lg-6">
                <label class="col-md-12 col-lg-4" for="txtPrenom">Prénom : </label>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-8" ID="txtPrenom" runat="server"></asp:TextBox>
            </div>
            <div class="form-group col-12 col-lg-6">
                <label for="txtEmail" class="col-md-12 col-lg-4">Email : </label>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-8" ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Email : Incorrect" ControlToValidate="txtEmail" ValidationExpression="^[^\W][a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\.[a-zA-Z]{2,4}$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-12 col-lg-6">
                <label for="txtTelephone" class="col-md-12 col-lg-4">Téléphone : </label>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-8" ID="txtTelephone" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator4" runat="server" ErrorMessage="Telephone : Saisir un numero valide" ControlToValidate="txtTelephone" ValidationExpression="(0|(0033))[1-9][0-9]{8}"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-6 mt-2">
                <label for="cbxProprio" class="col-6">Propriétaire Bailleur :  </label>
                <asp:CheckBox ID="cbxProprio" runat="server" Text="Oui"/>
            </div>
            <div class="form-group col-12 col-lg-12 mt-3">  
                <label for="txtPassword1" class="col-12"><h5>Password :</h5></label>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-6" ID="txtPassword1" runat="server"></asp:TextBox>
                <asp:TextBox CssClass="form-control col-md-12 col-lg-6" ID="txtPassword2" runat="server"></asp:TextBox>
                <%--Verification des passwords - Required + identique + regexp (8 car. 1 Maj 1 Chiffre 1 car spé ex : !Azerty1 --%>             
            <asp:CompareValidator Display="None" ID="CompareValidator2" runat="server" ErrorMessage="Password : Les deux Password ne sont pas identique." ControlToValidate="txtPassword2" ControlToCompare="txtPassword1"></asp:CompareValidator>
            <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword1"  ErrorMessage="Password : 8 car. min. 1 Maj. 1 Car. Spéc. 1 Chiffre - Ex. : !Azerty1" ValidationExpression="^(?=.*[!@#$%^&*-])(?=.*[0-9])(?=.*[A-Z]).{8,}$"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group col-12 col-lg-12 mt-3 text-center">
                <asp:Button ID="btnSubmit" runat="server" Text="Valider" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </figure>
</asp:Content>
