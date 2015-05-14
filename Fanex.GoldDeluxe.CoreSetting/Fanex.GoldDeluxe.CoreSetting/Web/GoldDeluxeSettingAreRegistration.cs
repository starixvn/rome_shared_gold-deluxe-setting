namespace Fanex.GoldDeluxe.CoreSetting.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using Fanex.GoldDeluxe.CoreSetting.Web.App_Start;

    public class GoldDeluxeSettingAreRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "GoldDeluxeSetting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            RouteConfig.RegisterRoutes(this.AreaName, context);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}