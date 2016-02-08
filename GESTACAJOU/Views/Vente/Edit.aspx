<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente>" %>

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
        <legend>Vente</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_AUTO) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_AUTO) %>
            <%: Html.ValidationMessageFor(model => model.ID_AUTO) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_PARTENAIRE) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_PARTENAIRE) %>
            <%: Html.ValidationMessageFor(model => model.ID_PARTENAIRE) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.MONTANT_TOTAL) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MONTANT_TOTAL) %>
            <%: Html.ValidationMessageFor(model => model.MONTANT_TOTAL) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.QTE_TOTAL) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.QTE_TOTAL) %>
            <%: Html.ValidationMessageFor(model => model.QTE_TOTAL) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.DATE_OPERATION) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.DATE_OPERATION) %>
            <%: Html.ValidationMessageFor(model => model.DATE_OPERATION) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.PARTENAIRE) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.PARTENAIRE) %>
            <%: Html.ValidationMessageFor(model => model.PARTENAIRE) %>
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
