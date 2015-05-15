namespace Fanex.GoldDeluxe.CoreSetting.Controllers
{
    using System.Globalization;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.SessionState;
    using Fanex.GoldDeluxe.CoreSetting.Configuration;

    [SessionState(SessionStateBehavior.ReadOnly)]
    public class BaseController : Controller
    {
        private readonly CultureInfo _defaultCulture = CultureInfo.CreateSpecificCulture("en-US");

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentLanguageKey = GoldDeluxeSettings.Settings.LanguageSessionKey;
            var currentLanguage = Session[currentLanguageKey] != null ? Session[currentLanguageKey].ToString() : string.Empty;

            if (!string.IsNullOrEmpty(currentLanguage))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentLanguage);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(currentLanguage);
                Thread.CurrentThread.CurrentCulture.DateTimeFormat = _defaultCulture.DateTimeFormat;
                Thread.CurrentThread.CurrentCulture.NumberFormat = _defaultCulture.NumberFormat;
            }

            base.OnActionExecuting(filterContext);
        }
    }
}