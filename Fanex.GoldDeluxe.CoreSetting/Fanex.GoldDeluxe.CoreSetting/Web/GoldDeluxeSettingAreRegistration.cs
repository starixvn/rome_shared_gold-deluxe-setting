namespace Fanex.GoldDeluxe.CoreSetting.Web
{
    using Fanex.GoldDeluxe.CoreSetting.Web.App_Start;
    using System.Web.Mvc;
    using System.Web.Optimization;

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
