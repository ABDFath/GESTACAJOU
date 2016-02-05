using System.Web;
using System.Web.Optimization;

namespace GESTACAJOU
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le Bundling, accédez à l’adresse http://go.microsoft.com/fwlink/?LinkId=254725 (en anglais)
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery_1_11.js", "~/Scripts/jquery-ui.js", "~/Scripts/jquery-1.8.3.min.js", "~/Scripts/jquery-1.10.2.js", "~/Scripts/jquery-1.8.3.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-2-1-4.js", "~/Scripts/jquery-ui.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js", "~/Scripts/bootbox.js", "~/Scripts/select2.js"
                        , "~/Scripts/colpick.js", "~/Scripts/typeahead.jquery.js", "~/Scripts/typeahead.jquery.min.js",
                        "~/Scripts/typeahead.bundle.js", "~/Scripts/typeahead.bundle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/slidereveal").Include(
                        "~/Scripts/slidereveal.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/sitecss").Include("~/Content/Site.css", "~/Content/select2.css",
                "~/Content/select2bootstrap.css", "~/Content/colpick.css", "~/Content/typeahead.js-bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/metro").Include("~/Content/metro-bootstrap.css", "~/Content/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                 "~/Content/themes/base/jquery-ui.css"       
                /*,"~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"*/
                 ));
        }
    }
}