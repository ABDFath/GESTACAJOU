<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Vente</legend>

    <div class="display-label">ID_AUTO</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_AUTO) %>
    </div>

    <div class="display-label">ID_PARTENAIRE</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_PARTENAIRE) %>
    </div>

    <div class="display-label">MONTANT_TOTAL</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.MONTANT_TOTAL) %>
    </div>

    <div class="display-label">QTE_TOTAL</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.QTE_TOTAL) %>
    </div>

    <div class="display-label">DATE_OPERATION</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DATE_OPERATION) %>
    </div>

    <div class="display-label">PARTENAIRE</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PARTENAIRE) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
