<%@ Page Title="" Language="C#" MasterPageFile="~/backend.Master" AutoEventWireup="true" CodeBehind="BackendMessagerie2.aspx.cs" Inherits="MRLoca.BackendMessagerie2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <h3>Espace Client<em class="lead"> - Messagerie</em></h3>
        <figure class="figure bg-white py-2 col-12 border shadow my-3 bg-white rounded">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <div class="col-3">
                <asp:ListView ID="lvwSujet" runat="server">
                    <ItemTemplate>
                        <ul class="list-group">
                            <asp:LinkButton ID="lbtDiscution" CssClass="list-group-item disabled" runat="server"></asp:LinkButton>
                        </ul>
                    </ItemTemplate>
                </asp:ListView>
            </div>                 
            <div class="col-3">
                <asp:ListView ID="lvwDiscussion" runat="server">
                    <ItemTemplate>
                        <ul class="list-group">
                            <asp:LinkButton ID="lbtDiscution" CssClass="list-group-item disabled" runat="server"></asp:LinkButton>
                        </ul>
                    </ItemTemplate>
                </asp:ListView>
            </div>
            
        </figure>
</asp:Content>
