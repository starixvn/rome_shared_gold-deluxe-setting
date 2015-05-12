namespace Fanex.GoldDeluxe.CoreSetting.Web.App_Start
{
    using System.Web.Mvc;

    public class RouteConfig
    {
        public static void RegisterRoutes(string areaName, AreaRegistrationContext context)
        {
            context.MapRoute(
                areaName + "_Default",
                "GoldDeluxeSetting/{controller}/{action}/{id}",
                new
                {
                    controller = "GoldDeluxeUser",
                    action = "UnAuthorized",
                    id = UrlParameter.Optional
                },
                new[]
                    {
                        typeof (Fanex.GoldDeluxe.CoreSetting.Controllers.SettingController).Namespace
                    });
        }
    }
}