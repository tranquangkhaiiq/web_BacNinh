using System.Web;
using System.Web.Optimization;

namespace webvl2024_BacNinh
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/js/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/AdminBSB-js").Include(
                     "~/Content/AdminBSB-cssjs/plugins/bootstrap/js/bootstrap.min.js",
                     "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/AdminBSB-css").Include(
                      "~/Content/AdminBSB-cssjs/plugins/bootstrap/css/bootstrap.min.css"
                       ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
