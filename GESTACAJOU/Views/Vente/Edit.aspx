<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.Vente>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Modifier une vente
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>GESTION DES VENTES</h2>

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
                    <h3 class="box-title">Modification d'une vente</h3>
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
                        <label>QUANTITE TOTALE</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                     <%: Html.TextBoxFor(m => m.QTE_TOTAL, new {@class ="form-control",autocomplete="off" }) %>
                      <%: Html.ValidationMessageFor(m=>m.QTE_TOTAL) %>
                   </div>
                   </div>
              </div>
              <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-2">
                        <label>MONTANT TOTAL</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                       <%: Html.TextBoxFor(m => m.MONTANT_TOTAL, new {@class ="form-control",autocomplete="off" }) %>
                        <%: Html.ValidationMessageFor(m=>m.MONTANT_TOTAL) %>
                   </div>
                   </div>
              </div>
                
             
              <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-2">
                        <label>DATE OPERATION</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                       <%: Html.TextBoxFor(m => m.DATE_OPERATION, new {@class ="form-control",autocomplete="off" }) %>
                       <%: Html.ValidationMessageFor(m=>m.DATE_OPERATION) %>
                   </div>
                   </div>
              </div>
              
                 <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-2">
                        <label>PARTENAIRE</label>
                   </div>
                  <div class="col-md-5">
                   <div class="form-group">
                       <%: Html.DropDownListFor(m => m.ID_PARTENAIRE,ViewData["PARTENAIRE"] as List<SelectListItem>,new { @class = "form-control select2"})%>
                       <%: Html.ValidationMessageFor(m=>m.PARTENAIRE) %>
                   </div>
                   </div>
              </div>
                 <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <p>
            <input type="submit" value="Modifier" class="btn btn-success" name="btnFormSubmit" id="btnFormSubmit" />
        </p>

                   </div>
              </div>
                  
              </div>
 </div>
         </div>
<% } %>


    <div>|
        <%: Html.ActionLink("Retour à la liste", "../Vente/IndexVente") %>
    </div>
</asp:Content>
