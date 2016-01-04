using System.Web;
using System.Web.Optimization;

namespace Waterbuffalortours
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/lib/bootstrap/dist/css/bootstrap.css",
                    "~/Content/lib/fontawesome/css/font-awesome.min.css",
                    "~/Content/lib/animsition/dist/css/animsition.css",
                    "~/Content/css/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/lib/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Content/lib/angular/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/lib/bootstrap/dist/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/ui-bootstrap").Include(
                     "~/Content/lib/angular-bootstrap/ui-bootstrap-tpls.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                      "~/Angularjs/Utils/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/homeController").Include(
                      "~/Angularjs/Controllers/HomeController.js"));

        }
    }
}
