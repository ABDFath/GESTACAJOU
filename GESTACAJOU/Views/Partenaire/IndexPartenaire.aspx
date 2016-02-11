<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<GESTACAJOU.Models.Partenaire>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    GESTCAJOU | Liste des partenaires
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>GESTION DES PARTENAIRES</h2>

    <div class="box-body table-responsive no-padding">
        <table class="table table-hover footable" data-page-size="2" data-limit-navigation="5">
            <thead>
                <tr>

                    <th>NOM
                    </th>
                    <th>PRENOM
                    </th>
                    <th>CONTACT
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in Model)
                   { %>
                <tr>

                    <td>
                        <%: Html.DisplayFor(modelItem => item.NOM) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.PRENOM) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.CONTACT) %>
                    </td>
                    
                    <td>
                        <%: Html.ActionLink("Nouveau Partenaire", "CreatePartenaire", new { /* id=item.PrimaryKey */ }) %> |
            <%: Html.ActionLink("Modifier", "ModifyPartener", new { id=item.ID_AUTO }) %> |
            <%: Html.ActionLink("Supprimer", "DeletePartener", new { id=item.ID_AUTO}) %>
                        <%--<%: Html.ActionLink("Details", "Details", new { id=item.ID_AUTO}) %>--%>
                    </td>
                </tr>
                <% } %>
            </tbody>


        </table>
    </div>

</asp:Content>
