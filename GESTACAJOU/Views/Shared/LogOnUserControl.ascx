<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Bienvenue <strong><%: Page.User.Identity.Name %></strong>!
        [ <%: Html.ActionLink("Se déconnecter", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("Se connecter", "LogOn", "Account") %> ]
<%
    }
%>
