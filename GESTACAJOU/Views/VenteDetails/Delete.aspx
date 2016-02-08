<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente_Details>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Vente_Details</legend>

    <div class="display-label">ID_AUTO</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_AUTO) %>
    </div>

    <div class="display-label">ID_VENTE</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_VENTE) %>
    </div>

    <div class="display-label">ID_CHARGEMENT</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_CHARGEMENT) %>
    </div>

    <div class="display-label">PRIX_UNITAIRE</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PRIX_UNITAIRE) %>
    </div>

    <div class="display-label">QTE</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.QTE) %>
    </div>

    <div class="display-label">TOTAL</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TOTAL) %>
    </div>

    <div class="display-label">CHARGEMENT</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.CHARGEMENT) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
