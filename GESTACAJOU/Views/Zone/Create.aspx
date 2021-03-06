﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Zone>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Nouvelle zone
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Nouvelle Zone</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
    <div class="row">
        <% using (Html.BeginForm())
           { %>
        <%: Html.ValidationSummary(true) %>
        <%: Html.AntiForgeryToken() %>
        <div class="col-xs-12">
            <div class="box box-info">
                <div class="box-header">
                    <h3 class="box-title">Créer une nouvelle Zone</h3>
                    <div class="box-tools pull-right">
                        <div class="label bg-aqua">&nbsp;</div>
                    </div>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                            <label>NOM</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.TextBoxFor(m => m.NOM, new {@class ="form-control",autocomplete="off" }) %>
                                <%: Html.ValidationMessageFor(m=>m.NOM) %>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                            <label>CONTROLEURS</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.DropDownListFor(m => m.ID_CONT,ViewData["CONTROLEUR"] as List<SelectListItem>, new {@class = "form-control select2"}) %>
                                <%: Html.ValidationMessageFor(m=>m.CONTROLEUR) %>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <p>
                            <input type="submit" value="Enregistrer" class="btn btn-success" name="btnFormSubmit" id="btnFormSubmit" />
                        </p>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <% } %>

    <div>
        <%: Html.ActionLink("Retour à la liste","../Zone/Index") %>
    </div>


</asp:Content>
