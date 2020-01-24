<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Paiement.aspx.cs" Inherits="MRLoca.Paiement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowSummary="true" CssClass="list-group-item list-group-item-danger"/>
    <h3>Paiement : </h3>
    <hr />
<asp:Label ID="lblErreur" runat="server" Text="Une erreur s'est produite" Visible="false"></asp:Label>
    <span class="badge badge-pill badge-info">Récapitulatif de ma réservation : </span>
    <%-- Information sur la réservation --%>
    <div class="row border rounded my-1 p-1 border-info">
        <div class="col-12 col-md-6">
            <asp:Image ID="imgHebergement" runat="server" CssClass="img-fluid"/>
        </div>
        <div class="col-12 col-md-6">
            <div class="col-12"><h5><asp:Label ID="lblTitre" runat="server" Text=""></asp:Label></h5></div>
            <div class="col-12"><asp:Label ID="lblDescription" runat="server" Text=""></asp:Label></div>
            <hr />
            <div class="col-12"><h5>Adresse : </h5></div>
            <div class="col-12"><asp:Label ID="lblAdresse" runat="server" Text=""></asp:Label></div>
        </div>
        <div class="row col-12 col-md-12">
            <div class="col-12 col-md-5">
                <div class="col-12"><h5>Date d'entrée</h5></div>
                <asp:TextBox ID="txtDateDebut" runat="server" TextMode="Date"></asp:TextBox>
                <asp:TextBox ID="txtaujourdhui" runat="server" TextMode="Date" Visible="false"></asp:TextBox>
                <asp:RequiredFieldValidator CssClass="badge badge-danger" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date de debut doit être choisi" ControlToValidate="txtDateDebut"></asp:RequiredFieldValidator>
                <asp:CompareValidator CssClass="badge badge-danger" Display="Dynamic" ControlToValidate="txtDateDebut" ControlToCompare="txtaujourdhui" Operator="GreaterThan" ID="CompareValidator2" runat="server" ErrorMessage="La date de début doit être posterieur à la date du jour"></asp:CompareValidator>
            </div>
            <div class="col-12 col-md-5">
                <div class="col-12"><h5>Date de sortie</h5></div>
                <div class="col-12"><asp:TextBox ID="txtDateFin" runat="server" TextMode="Date"></asp:TextBox></div> 
                <asp:RequiredFieldValidator CssClass="badge badge-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Date de fin doit être choisi" ControlToValidate="txtDateFin"></asp:RequiredFieldValidator>
                <asp:CompareValidator CssClass="badge badge-danger" ID="CompareValidator1" runat="server" ErrorMessage="La Date de Debut doit être antérieur à la date de fin" ControlToCompare="txtDateDebut" ControlToValidate="txtDateFin" Operator="GreaterThan"></asp:CompareValidator>
            </div>
            <div class="col-12 col-md-2">
                <asp:Button ID="btnPrix" runat="server" Text="Calcul Prix" OnClick="btnPrix_Click"/>
            </div>
        </div>
    </div>
    <%-- Mode de paiement --%>
    <div class="row border rounded my-1 p-1 border-info text-center">
            <asp:DropDownList ID="ddlPaiement" runat="server" CssClass="col-12 form-control input-lg my-2">                
            </asp:DropDownList>
            <asp:RequiredFieldValidator CssClass="badge badge-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Choisir votre mode de paiement" ControlToValidate="ddlPaiement"></asp:RequiredFieldValidator>
    </div>
    <%-- Btn Prix + btn paiement--%>
    <div class="row border rounded my- p-1 border-info">

            <div class="col-auto mr-auto my-auto">
                Montant à payer : <asp:Label ID="lblPrix" runat="server" Text=""></asp:Label> Eur. pour <asp:Label ID="lblDuree" runat="server" Text=""></asp:Label> Jour(s)
            </div>
            <div class="col-auto my-auto">
                <asp:Button ID="btnPayer" runat="server" Text="Payer" CssClass="btn btn-danger" OnClick="btnPayer_Click"/>
            </div>


    </div>

</asp:Content>
