<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<GESTACAJOU.Models.PisteurModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
   GEST CAJOU | Nouveau Pisteur
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div class="row">
        <% using (Html.BeginForm("Ajout", "Pisteur" ))   
           { %>
          <%: Html.AntiForgeryToken() %>
         <div class="col-xs-12">
            <div class="box box-info">
                 <div class="box-header">
                    <h3 class="box-title">AJOUTER PISTEUR</h3>
                    <div class="box-tools pull-right">
                        <div class="label bg-aqua">&nbsp;</div>
                    </div>
                </div>
             <div class="box-body">
              <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-1">
                        <label>Nom</label>
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
                   <div class="col-md-1">
                        <label>Prénom</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                       <%: Html.TextBoxFor(m => m.PRENOM, new {@class ="form-control",autocomplete="off" }) %>
                        <%: Html.ValidationMessageFor(m=>m.PRENOM) %>
                   </div>
                   </div>
              </div>
                
             
              <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-1">
                        <label>Téléphone</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                       <%: Html.TextBoxFor(m => m.TEL, new {@class ="form-control",autocomplete="off" }) %>
                       <%: Html.ValidationMessageFor(m=>m.TEL) %>
                   </div>
                   </div>
              </div>
              
                 <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-1">
                        <label>Village</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                     <%--<input type="text" class="form-control" id="telVal" placeholder="">--%>
                       <%: Html.TextBoxFor(m => m.VILLAGE, new {@class ="form-control",autocomplete="off" }) %>
                       <%: Html.ValidationMessageFor(m=>m.VILLAGE) %>
                   </div>
                   </div>
              </div>
                 <div class="row">
                   <div class="col-md-2">
                        &nbsp;
                   </div>
                   <div class="col-md-1">
                        <label>Zone</label>
                   </div>
                   <div class="col-md-5">
                   <div class="form-group">
                     <%--<input type="text" class="form-control" id="telVal" placeholder="">--%>
                       <%: Html.DropDownListFor(m => m.ID_ZONE,ViewData["ZONE"] as List<SelectListItem>, new {@class = "form-control select2"})  %>
                       <%: Html.ValidationMessageFor(m=>m.VILLAGE) %>
                   </div>
                   </div>
              </div>
                  
              </div>
             
                  <div class="box-footer" style="text-align:right">
                                  <button type="reset" class="btn btnresetpromoteur">ANNULER</button> 
                                        	<button type="submit" class="btn btn-success" name="btnFormSubmit" id="btnFormSubmit">ENREGISTRER</button>

                                </div> 
             </div>
             
                </div>
      <% } %>
       <div class="col-xs-12">
                            <div class="box">
                                  <div class="box-header">
                                      <div class="row">
                                          <div class="col-md-9">
                                               
                                           </div>
                                           <div style="text-align:right;" class="col-md-2">
                                                Pisteurs:&nbsp;<label> <%: Model.ListPisteurs.Count %> </label>
                                           </div>
                                      </div>
                                  
                                    <div class="box-tools">
                                       
                                    </div>
                                </div><!-- /.box-header -->
                                <div class="box-body table-responsive no-padding">
                                    <table class="table table-hover footable" data-page-size="2" data-limit-navigation="5">
                                        <thead><tr>
                                            <th>ID</th>
                                            <th>NOM </th>
                                            <th>PRENOM</th>
                                            <th>VILLAGE</th>
                                            <th>TELEPHONE</th>
                                            <th>ZONE</th>
                                        </tr>

                                        </thead>
                                        <tbody>
                                         
                                            <% foreach (var item in Model.ListPisteurs) { %>
    <tr>
         <td>
            <a href="#" style="color:blue;" id="<%: Html.DisplayFor(modelItem => item.ID_AUTO)%>" class="editLink"><%: Html.DisplayFor(modelItem => item.ID_AUTO)%></a> 
        </td>
       
         <td>
            <%: Html.DisplayFor(modelItem => item.NOM) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.PRENOM) %>
        </td>

        <td>
            <%: Html.DisplayFor(modelItem => item.VILLAGE) %>
        </td>

        <td>
            <%: Html.DisplayFor(modelItem => item.TEL) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.ZONE) %>&nbsp;
        </td>
          
    </tr>
<% } %>



                                       </tbody>
                                        
                                    </table>
                                    <br />

                                   <%--Page <%:Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber %> à <%:Model.PageCount %>
                                    <%:Html.PagedListPager(Model, page => Url.Action("List", new { page })) %>--%>
                                </div><!-- /.box-body -->
                                 
                                
                            </div><!-- /.box -->
                        </div>
           


             </div>
         

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptsSection" runat="server">
     <script type="text/javascript">
         $(document).ready(function () {
             $(".editLink").click(function (e) {

                 var $this = $(this);
                 var num = $this.attr("id");
                 var redirect = "/Pisteur/Ajout/" + num;
                 $this.attr("href", redirect)


             });
         });
          </script>
</asp:Content>
