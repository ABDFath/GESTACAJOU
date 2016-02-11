<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Vente>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Liste des ventes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GESTION DES VENTES</h2>

    <div class="box-body table-responsive no-padding">
        <table class="table table-hover footable" data-page-size="2" data-limit-navigation="5">
            <thead>
                <tr>

                    <th>MONTANT TOTAL
                    </th>
                    <th>QUANTITE TOTALE
                    </th>
                    <th>DATE OPERATION
                    </th>
                    <th>PARTENAIRE
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Model)
                   { %>
                <tr>

                    <td>
                        <%: Html.DisplayFor(modelItem => item.MONTANT_TOTAL) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.QTE_TOTAL) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.DATE_OPERATION) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.PARTENAIRE) %>
                    </td>
                    <td>
                        <%: Html.ActionLink("Nouvelle Vente", "Create", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Modifier", "Edit", new { id=item.ID_AUTO }) %> |
            <%: Html.ActionLink("Supprimer", "Delete", new { id=item.ID_AUTO}) %>
                        <%--<%: Html.ActionLink("Details", "Details", new { id=item.ID_AUTO}) %>--%>
                    </td>
                </tr>
                <% } %>
            </tbody>


        </table>
    </div>
    <%--<div class="box-footer" style="text-align:right">
                      
                      <button type="submit" class="btn btn-success" name="btnFormSubmit" id="btnFormSubmit" onclick="Create">NOUVELLE VENTE</button>
              <button type="submit" class="btn btn-success" name="btnFormSubmit1" id="Button1">MODIFIER</button>
<button type="submit" class="btn btn-success" name="btnFormSubmit2" id="Button2" onclick="DeleteButton_Click">SUPPRIMER</button>
              <button type="reset" class="btn btnresetpromoteur">ANNULER</button> 
     </div> --%>
</asp:Content>
