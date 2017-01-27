using System.Web;
using System.Web.Optimization;

namespace SaudaMaster.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/bootstrap-reset.css",
                     "~/Content/owl.carousel.css",
                     "~/Content/font-awesome.css",
                     "~/Content/jquery.easy-pie-chart.css",
                     "~/Content/style.css",
                     "~/Content/style-responsive.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.js",
                      "~/Scripts/jquery-1.8.3.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.dcjqaccordion.2.7.js",
                      "~/Scripts/jquery.scrollTo.min.js",
                      "~/Scripts/jquery.nicescroll.js",
                      "~/Scripts/jquery.sparkline.js",
                      "~/Scripts/jquery.easy-pie-chart.js",
                      "~/Scripts/owl.carousel.js",
                      "~/Scripts/jquery.customSelect.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/sparkline-chart.js",
                      "~/Scripts/easy-pie-chart.js",
                      "~/Scripts/count.js",
                      "~/Scripts/common-scripts.js"
                      ));

        }
    }
}
