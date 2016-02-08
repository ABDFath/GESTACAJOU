<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Vente_Details>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            ID_AUTO
        </th>
        <th>
            ID_VENTE
        </th>
        <th>
            ID_CHARGEMENT
        </th>
        <th>
            PRIX_UNITAIRE
        </th>
        <th>
            QTE
        </th>
        <th>
            TOTAL
        </th>
        <th>
            CHARGEMENT
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_AUTO) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_VENTE) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_CHARGEMENT) %>
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
            <%: Html.DisplayFor(modelItem => item.CHARGEMENT) %>
        </td>
        <td>
            <%: Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }) %>
        </td>
    </tr>
<% } %>

</table>

</asp:Content>
