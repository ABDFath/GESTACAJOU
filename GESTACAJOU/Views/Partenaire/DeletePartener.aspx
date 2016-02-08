<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Partenaire>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    DeletePartener
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>DeletePartener</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>Partenaire</legend>

    <div class="display-label">ID_AUTO</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ID_AUTO) %>
    </div>

    <div class="display-label">NOM</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NOM) %>
    </div>

    <div class="display-label">PRENOM</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.PRENOM) %>
    </div>

    <div class="display-label">CONTACT</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.CONTACT) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Delete" /> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>
<% } %>

</asp:Content>
