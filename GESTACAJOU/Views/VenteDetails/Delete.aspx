<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente_Details>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Supprimer les détails d'une vente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GESTION DES DETAILS VENTES</h2>
    <h3>Etes vous sûr de vouloir supprimer ces details vente?</h3>

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
                    <h3 class="box-title">Suppression des détails d'une vente</h3>
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
                            <label>VENTE</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.DropDownListFor(m => m.ID_VENTE,ViewData["VENTE"] as List<SelectListItem>, new {@class = "form-control select2"}) %>
                                <%: Html.ValidationMessageFor(m=>m.VENTE) %>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                         <div class="col-md-2">
                            <label>CHARGEMENT</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.DropDownListFor(m => m.ID_CHARGEMENT,ViewData["CHARGEMENT"] as List<SelectListItem>, new {@class = "form-control select2"}) %>
                                <%: Html.ValidationMessageFor(m=>m.CHARGEMENT) %>
                            </div>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                            <label>PRIX UNITAIRE</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.TextBoxFor(m => m.PRIX_UNITAIRE, new {@class ="form-control",autocomplete="off" }) %>
                                <%: Html.ValidationMessageFor(m=>m.PRIX_UNITAIRE) %>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                            <label>QUANTITE</label>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <%: Html.TextBoxFor(m => m.QTE, new {@class ="form-control",autocomplete="off" }) %>
                                <%: Html.ValidationMessageFor(m=>m.QTE) %>
                            </div>
                        </div>
                    </div>
                     <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <div class="col-md-2">
                        <label>TOTAL</label>
                    </div>
                    <div class="col-md-5">
                        <div class="form-group">
                            <%: Html.TextBoxFor(m => m.TOTAL, new {@class ="form-control",autocomplete="off" }) %>
                            <%: Html.ValidationMessageFor(m=>m.TOTAL) %>
                        </div>
                    </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            &nbsp;
                        </div>
                        <p>
                            <input type="submit" value="Supprimer" class="btn btn-success" name="btnFormSubmit" id="btnFormSubmit" />
                        </p>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <% } %>


    <div>
        |
        <%: Html.ActionLink("Retour à la liste", "../VenteDetails/Index") %>
    </div>


</asp:Content>
