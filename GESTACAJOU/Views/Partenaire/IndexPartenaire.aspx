<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Partenaire>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    IndexPartenaire
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>IndexPartenaire</h2>

<p>
    <%: Html.ActionLink("Create New", "Create") %>
</p>
<table>
    <tr>
        <th>
            ID_AUTO
        </th>
        <th>
            NOM
        </th>
        <th>
            PRENOM
        </th>
        <th>
            CONTACT
        </th>
        <th></th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.ID_AUTO) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.NOM) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.PRENOM) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.CONTACT) %>
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
