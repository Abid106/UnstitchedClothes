using System.Web;
using System.Web.Optimization;

namespace UnstitchedClothes
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Plugins/datatables/datatables.min.css",
                      "~/Plugins/datatables/plugins/bootstrap/datatables.bootstrap.css",
                        "~/Content/stylesheets/bootstrap.css",
                        "~/Content/stylesheets/style.css",
                        "~/Content/stylesheets/responsive.css",
                        "~/Content/stylesheets/colors/color1.css",
                        "~/Content/stylesheets/animate.css",
                        "~/Content/icon/favicon.png",
                      "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/bundles/Jsfiles").Include(
                   "~/Plugins/datatables/datatables.min.js",
                     "~/Plugins/datatables/plugins/bootstrap/datatables.bootstrap.js"
                       ));
        }
    }
}
