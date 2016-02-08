<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Vente>>" %>

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
            ID_PARTENAIRE
        </th>
        <th>
            MONTANT_TOTAL
        </th>
        <th>
            QTE_TOTAL
        </th>
        <th>
            DATE_OPERATION
        </th>
        <th>
            PARTENAIRE
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_AUTO) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_PARTENAIRE) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.MONTANT_TOTAL) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.QTE_TOTAL) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.DATE_OPERATION) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.PARTENAIRE) %>
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
