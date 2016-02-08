﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Partenaire>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ModifyPartener
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>ModifyPartener</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Partenaire</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.ID_AUTO) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ID_AUTO) %>
            <%: Html.ValidationMessageFor(model => model.ID_AUTO) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.NOM) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NOM) %>
            <%: Html.ValidationMessageFor(model => model.NOM) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.PRENOM) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.PRENOM) %>
            <%: Html.ValidationMessageFor(model => model.PRENOM) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.CONTACT) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.CONTACT) %>
            <%: Html.ValidationMessageFor(model => model.CONTACT) %>
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