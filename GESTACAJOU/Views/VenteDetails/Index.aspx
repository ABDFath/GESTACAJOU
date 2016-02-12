<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Vente_Details>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Liste détails nouvelle vente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GESTION DES DETAILS VENTES</h2>
    <div class="box-body table-responsive no-padding">
        <table class="table table-hover footable" data-page-size="2" data-limit-navigation="5">
            <thead>
                <tr>

                    <th>VENTE
                    </th>
                    <th>CHARGEMENT
                    </th>
                    <th>PRIX UNITAIRE
                    </th>
                    <th>QUANTITE
                    </th>
                    <th>TOTAL
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Model)
                   { %>
                <tr>

                    <td>
                        <%: Html.DisplayFor(modelItem => item.VENTE) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.CHARGEMENT) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.PRIX_UNITAIRE) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.QTE) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.TOTAL) %>
                    </td>
                    <td>
                        <%: Html.ActionLink("Nouveaux Details", "Create", new { /* id=item.PrimaryKey */ }) %> |
                        <%: Html.ActionLink("Modifier", "Edit", new { id=item.ID_AUTO }) %> |
                        <%: Html.ActionLink("Supprimer", "Delete", new { id=item.ID_AUTO}) %>
                        <%--<%: Html.ActionLink("Details", "Details", new { id=item.ID_AUTO}) %>--%>
                    </td>
                </tr>
                <% } %>
            </tbody>

        </table>
    </div>
</asp:Content>
