<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente_Details>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Vente_Details</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_AUTO) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_AUTO) %>
            <%: Html.ValidationMessageFor(model => model.ID_AUTO) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_VENTE) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_VENTE) %>
            <%: Html.ValidationMessageFor(model => model.ID_VENTE) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_CHARGEMENT) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_CHARGEMENT) %>
            <%: Html.ValidationMessageFor(model => model.ID_CHARGEMENT) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.PRIX_UNITAIRE) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.PRIX_UNITAIRE) %>
            <%: Html.ValidationMessageFor(model => model.PRIX_UNITAIRE) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.QTE) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.QTE) %>
            <%: Html.ValidationMessageFor(model => model.QTE) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.TOTAL) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.TOTAL) %>
            <%: Html.ValidationMessageFor(model => model.TOTAL) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CHARGEMENT) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.CHARGEMENT) %>
            <%: Html.ValidationMessageFor(model => model.CHARGEMENT) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
