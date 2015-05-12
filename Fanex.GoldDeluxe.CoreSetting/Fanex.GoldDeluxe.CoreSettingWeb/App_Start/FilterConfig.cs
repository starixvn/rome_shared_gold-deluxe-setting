using System.Web;
using System.Web.Mvc;

namespace Fanex.GoldDeluxe.CoreSettingWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}