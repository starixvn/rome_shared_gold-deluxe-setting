namespace Fanex.GoldDeluxe.CoreSetting.Web.App_Start
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterStyleSheetBundles(bundles);
            RegisterJavascriptBundles(bundles);
        }

        private static void RegisterJavascriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/areasjs/golddeluxe/core")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/jquery-1.11.1.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/jquery.blockUI.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/numeral.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/angular.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/angular-sanitize.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/libs/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/areasjs/golddeluxe/setting")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/gold-deluxe-lang.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.en-US.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.ja-JP.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.ko-KR.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.th-TH.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.vi-VN.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.zh-CN.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/language/GoldDeluxeLang.zh-TW.js")
                .Include("~/areas/GoldDeluxeSetting/scripts/core/fanex-gold-deluxe-setting.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/services/cust-setting-service.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/services/cust-game-setting-service.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/services/pt-and-com-setting-service.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/controllers/cust-info-controller.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/controllers/cust-setting-controller.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/controllers/pt-and-com-setting-controller.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/controllers/cust-game-setting-controller.js")
                .Include("~/areas/GoldDeluxeSetting/views/editsetting/scripts/directives/pt-and-com-setting-directive.js"));
        }

        private static void RegisterStyleSheetBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/areas/GoldDeluxeSetting/content/bundlecss")
                .Include("~/areas/GoldDeluxeSetting/content/bootstrap.css")
                .Include("~/areas/GoldDeluxeSetting/content/fanex-gold-deluxe-setting.css")
                .Include("~/areas/GoldDeluxeSetting/content/fanex-gold-deluxe-setting-override.css"));
        }
    }
}