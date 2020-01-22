<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="connection.aspx.cs" Inherits="MRLoca.connection" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
        <div class="text-center py-2 my-1">
            <asp:Label ID="lblClient" runat="server" Text="Login et/ou Password Incorrect" class="alert alert-danger col-12" Visible="false"></asp:Label>
            <asp:Label ID="lblMsg" runat="server" Text="" class="alert alert-info col-12" Visible="false"></asp:Label>
        </div>
        <figure class="figure bg-white py-2 col-12 border shadow my-2 bg-white rounded">            
            <div>
                <div class="form-inline">
                    <label for="exampleInputEmail1" class="d-none d-sm-block col-12 col-md-4">Login : </label>
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Entrer votre login" CssClass="form-control col-12 col-md-8" TextMode="SingleLine"></asp:TextBox>
                    <asp:RequiredFieldValidator Display="None" ControlToValidate="txtEmail" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Veuillez Saisir un Email"></asp:RequiredFieldValidator>
    <%--                <asp:RegularExpressionValidator Display="None" ControlToValidate="txtEmail" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Veuillez saisir un email correct" ValidationExpression="^[^\W][a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\@[a-zA-Z0-9_]+(\.[a-zA-Z0-9_]+)*\.[a-zA-Z]{2,4}$"></asp:RegularExpressionValidator>--%>
                </div>
                <div class="form-inline">
                    <label for="exampleInputPassword1" class="d-none d-sm-block col-12 col-md-4">Password : </label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" CssClass="form-control col-12 col-md-8"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
                <div class="text-center col-12">
                    <asp:Button ID="btnValider" runat="server" Text="Valider" OnClick="btnValider_Click" class="btn btn-primary text-center"/>
                </div>            
            </div>
        </figure>

        <div class="text-center my-2">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/CreerCompte.aspx" CssClass="btn btn-info">Créer un compte Client</asp:HyperLink>
        </div>
</asp:Content>
