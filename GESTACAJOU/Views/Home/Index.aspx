<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Page d'accueil
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: ViewBag.Message %></h2>
    <p>
        Pour en savoir plus sur ASP.NET MVC, visitez le site <a href="http://asp.net/mvc" title="Site Web ASP.NET MVC">http://asp.net/mvc</a>.
    </p>
</asp:Content>
