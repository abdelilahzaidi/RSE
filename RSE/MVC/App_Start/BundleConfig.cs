using System.Web;
using System.Web.Optimization;

namespace MVC
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/fullCalendar").Include(
                      "~/Content/fullcalendar.css"));

            bundles.Add(new ScriptBundle("~/bundles/fullCalendar").Include(
                      "~/Scripts/jquery-3.3.1.min.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/fullcalendar.js",
                      "~/Scripts/locale-all.js"));

            bundles.Add(new StyleBundle("~/Content/RSE_Style").Include(
                      "~/Content/RSE_Style.css",
                      "~/Content/RSE_NavBar.css"));
            
            bundles.Add(new StyleBundle("~/Content/RSE_StyleAdmin").Include(
                      "~/Content/RSE_Style.css",
                      "~/Content/RSE_NavBar.css",
                      "~/Content/RSE_NavBarAdmin.css"));

            bundles.Add(new ScriptBundle("~/bundles/RSE_Style").Include(
                      "~/Scripts/RSE_NavBar.js"));
        }
    }
}
