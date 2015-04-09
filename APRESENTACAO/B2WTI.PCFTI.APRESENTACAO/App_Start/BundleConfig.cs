
namespace B2WTI.PCFTI.APRESENTACAO.App_Start
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Jquery Framework
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/js/jquery.framework/jquery-{version}.js"));

            //Jquery Validate
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/js/jquery.framework/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/js/jquery.framework/modernizr-*"));

            //Javascript Jquery Edit Table - Complemento DataTables para Arrows
            bundles.Add(new ScriptBundle("~/bundles/jeditable").Include(
                        "~/js/jquery.editable/jquery.jeditable.js",
                        "~/js/jquery.editable/jquery.keytable.js"));

            //Javascript Bootstrap Page
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/js/jquery.bootstrap/bootstrap.js",
                        "~/js/jquery.bootstrap/respond.js"));

            //Javascript Metis Menu Page
            bundles.Add(new ScriptBundle("~/bundles/MetisMenu").Include(
                        "~/js/jquery.metismenu/jquery.metismenu.js"));

            //Javascript Slim Scroll Page
            bundles.Add(new ScriptBundle("~/bundles/SlimScroll").Include(
                        "~/js/jquery.slimscroll/jquery.slimscroll.js"));

            //Javascript DataTables Generic Fixed Column Page
            bundles.Add(new ScriptBundle("~/bundles/iniDataTableFixedColumn").Include(
                        "~/js/jquery.generic/jquery.generic.inidatatablefixedcolumn.js"));

            //Javascript Edit Table Page
            bundles.Add(new ScriptBundle("~/bundles/EditTable").Include(
                        "~/js/jquery.editable/jquery.editable.js"));

            bundles.Add(new ScriptBundle("~/bundles/ICheck").Include(
            "~/js/jquery.Icheck/jquery.ICheck.js"));

            //Javascript Data Tables Page
            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                        "~/js/jquery.datatables/jquery.dataTables.js",
                        "~/js/jquery.datatables/dataTables.fixedColumns.js",
                        "~/js/jquery.datatables/dataTables.tableTools.js",
                        "~/js/jquery.datatables/dataTables.colVis.js",
                        "~/js/jquery.datatables/dataTables.bootstrap.js",
                        "~/js/jquery.datatables/dataTables.responsive.js",
                        "~/js/jquery.datatables/dataTables.editor.js",
                        "~/js/jquery.datatables/dataTables.keyTable.js",
                        "~/js/jquery.datatables/dataTables.autoFill.js",
                        "~/js/jquery.datatables/dataTables.scroller.js"));




            //Javascript Data Tables Page
            bundles.Add(new ScriptBundle("~/bundles/DataTables/shCore").Include(
                        "~/js/jquery.datatables/resources/syntax/shCore.js"));

            //Javascript Dashboard Inspinia Page
            bundles.Add(new ScriptBundle("~/bundles/DashboardInspinia").Include(
                        "~/js/jquery.inspinia/jquery.inspinia.js",
                        "~/js/jquery.pace/jquery.pace.js"));


            //Style Bootstrap Page
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/css/bootstrap.css"));

            //Style Page
            bundles.Add(new StyleBundle("~/Content/Style").Include(
                        "~/css/style.css"));

            bundles.Add(new StyleBundle("~/Content/StyleICheck").Include(
                        "~/css/ICheckCustom.css"));


            //Style Animate Page
            bundles.Add(new StyleBundle("~/Content/css/Animate").Include(
                        "~/css/animate.css"));

            //Style Font Page
            bundles.Add(new StyleBundle("~/Content/css/FontAwesome").Include(
                        "~/fonts/css/font-awesome.css"));

            //Style DataTables Page
            bundles.Add(new StyleBundle("~/Content/css/DataTables").Include(
                        //"~/css/stylesheet.datatables/css/dataTables.bootstrap.css",
                        "~/css/stylesheet.datatables/css/jquery.dataTables.css",
                        "~/css/stylesheet.datatables/css/dataTables.fixedColumns.css",
                        "~/css/stylesheet.datatables/css/dataTables.responsive.css",
                        "~/css/stylesheet.datatables/css/dataTables.tableTools.css",
                        "~/css/stylesheet.datatables/css/dataTables.colVis.css",
                        "~/css/stylesheet.datatables/css/dataTables.keyTable.css",
                        "~/js/jquery.datatables/resources/syntax/shCore.css",
                        "~/css/stylesheet.datatables/css/dataTables.autoFill.css",
                        "~/css/stylesheet.datatables/css/dataTables.scroller.css"));

        }
    }
}