<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MRLoca._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--Creation du carrousel avec X photos aleatoirement choisies dans CS--%>
    <asp:Literal ID="litCarousel" runat="server"></asp:Literal>
   
    <%-- debut du formulaire--%>
    <figure class="figure bg-white py-2 col-12 border shadow my-2 bg-white rounded">
        <h4>Recherche : </h4>
        <div class="form-inline Text-Center">
            <div class="form-group col-12 col-lg-6">
                <label for="ddlDepartement" class="col-md-12 col-lg-4">Département : </label>
                <asp:DropDownList CssClass="form-control col-md-12 col-lg-8" ID="ddlDepartement" runat="server">
                    <asp:ListItem>Département</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Literal ID="litType" runat="server"></asp:Literal>
            <div class="form-group col-12 col-lg-6">
                <label class="col-md-12 col-lg-4" for="ddlType">Type : </label>
                <asp:DropDownList CssClass="form-control col-md-12 col-lg-8" ID="ddlType" runat="server"> 
                    <asp:ListItem>Mode de Paiement</asp:ListItem>
                </asp:DropDownList>
            </div>     
            <div class="text-center col-12 mt-2">
                <asp:Button CssClass="btn btn-info" ID="btnValidation" runat="server" Text="Rechercher" OnClick="btnValidation_Click"/>
            </div>
        </div>
    </figure>
</asp:Content>
